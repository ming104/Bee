using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("Panel")]
    [SerializeField] private GameObject GameEnd_Panel;

    [Header("GameLogic")]
    [SerializeField] private int Score;
    [SerializeField] private TMPro.TextMeshProUGUI Score_Text;

    [Header("GameEnd")]
    [SerializeField] private TMPro.TextMeshProUGUI ScoreCount;



    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    void Start()
    {
        GameEnd_Panel.SetActive(false);
        StartCoroutine(ScoreUP());
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score : " + Score;
    }

    IEnumerator ScoreUP()
    {
        while (true)
        {
            Score += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void EnemyKill_ScoreUP()
    {
        Score += 100;
    }

    public void GameEnd_Panel_On()
    {
        SoundManager.instance.PlaySound("GameOver");
        FirebaseManger.instance.SaveRanking(Score);
        FirebaseManger.instance.RemoveRankingData();
        GameEnd_Panel.SetActive(true);
        Time.timeScale = 0;
        ScoreCount.text = Score.ToString();
    }

    public void GameReStart()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("GameStart");
        Time.timeScale = 1;
    }

}
