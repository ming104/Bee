using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float Speed; // 플레이어 속도
    private Vector2 MousePos; // 마우스 좌표를 저장하기위한 Vector
    Camera cam; //카메라

    [SerializeField] private bool IsDead;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // 메인 카메라를 넣음
        IsDead = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.PlaySound("Touch");
        }
        if (Input.GetMouseButton(0)) // 마우스를 꾹 누를때 (핸드폰을 꾹 누를때)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x < 0f) pos.x = 0f;
            if (pos.x > 1f) pos.x = 1f;
            if (pos.y < 0f) pos.y = 0f;
            if (pos.y > 1f) pos.y = 1f;
            MousePos = cam.ScreenToWorldPoint(Input.mousePosition); // ScreenToWorldPoint를 사용해서 카메라의 월드좌표로 변환

            //방향을 토대로 움직임
            gameObject.transform.position = Vector2.MoveTowards(transform.position, MousePos, Speed * Time.deltaTime);

            float angle;
            angle = Mathf.Atan2(MousePos.y - gameObject.transform.position.y, MousePos.x - gameObject.transform.position.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !IsDead)
        {
            GameManager.instance.GameEnd_Panel_On();
            IsDead = true;
        }
    }
}
