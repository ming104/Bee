using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_missile_Used : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Bee");
        //StartCoroutine(Destroyobj());
    }


    [SerializeField] private float circleR; //반지름
    [SerializeField] private float deg; //각도
    [SerializeField] private float objSpeed = 3f; //원운동 속도

    void Update()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg < 720)
        {
            var rad = Mathf.Deg2Rad * deg; // Deg2Rad이거는 각도를 라디안으로 바꿔주는 코드
            var x = circleR * Mathf.Sin(rad); // x에다가 sin rad를 곱하면 원 나옴
            var y = circleR * Mathf.Cos(rad); // 마찬가지로
            gameObject.transform.position = Player.transform.position + new Vector3(x, y); // 값을 넣어줌
        }
        else
        {
            Destroy(gameObject);
        }
    }


    IEnumerator Destroyobj()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(this.gameObject);
    }
}
