using System.Linq;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseManger : MonoBehaviour
{
    public static FirebaseManger instance = null;

    DatabaseReference dbReference;
    // Start is called before the first frame update
    public List<TMPro.TextMeshProUGUI> Ranking_Text = new List<TMPro.TextMeshProUGUI>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveRanking(int score)
    {
        var newRankingEntry = dbReference.Child("Ranking").Push();
        newRankingEntry.Child("Score").SetValueAsync(score);
    }

    public void LoadRanking()
    {
        dbReference.Child("Ranking").OrderByChild("Score").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                // 새로운 리스트를 만들어 정렬된 순서로 데이터를 저장
                List<int> scores = new List<int>();
                foreach (var childSnapshot in snapshot.Children)
                {
                    int score = int.Parse(childSnapshot.Child("Score").Value.ToString());
                    scores.Add(score);
                }

                // 내림차순으로 정렬된 점수를 Text 배열에 저장
                scores = scores.OrderByDescending(x => x).ToList();

                for (int i = 0; i < scores.Count && i < Ranking_Text.Count; i++)
                {
                    Debug.Log("Debug: i=" + i + ", scores.Count=" + scores.Count + ", Ranking_Text.Count=" + Ranking_Text.Count);
                    Ranking_Text[i].text = (i + 1) + "등 : " + scores[i] + "점";
                }
            }
        });
    }

    public void RemoveRankingData()
    {
        dbReference.Child("Ranking").OrderByChild("Score").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                List<int> scores = new List<int>();
                foreach (var childSnapshot in snapshot.Children)
                {
                    int score = int.Parse(childSnapshot.Child("Score").Value.ToString());
                    scores.Add(score);
                }

                // 내림차순으로 정렬
                scores = scores.OrderByDescending(x => x).ToList();

                int thresholdRank = 5; // 5등 아래 데이터 삭제

                // 상위 5개 데이터를 제외한 나머지 데이터 삭제
                for (int i = thresholdRank; i < scores.Count; i++)
                {
                    int scoreToRemove = scores[i];

                    // 해당 점수를 가진 데이터를 찾아 삭제
                    foreach (var childSnapshot in snapshot.Children)
                    {
                        int snapshotScore = int.Parse(childSnapshot.Child("Score").Value.ToString());
                        if (snapshotScore == scoreToRemove)
                        {
                            childSnapshot.Reference.RemoveValueAsync(); // 데이터 삭제
                            break; // 찾은 후 바로 종료
                        }
                    }
                }
            }
        });
    }
}
