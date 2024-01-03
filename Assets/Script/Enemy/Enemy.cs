using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private float DestroyTime = 5f;

    void Update()
    {
        Vector2 newPos = Player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
    }

    private void OnEnable()
    {
        StartCoroutine(EnemyReturn());
        Player = GameObject.Find("Bee").transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            GameManager.instance.EnemyKill_ScoreUP();
            Enemy_Pool.ReturnObject(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            GameManager.instance.EnemyKill_ScoreUP();
            Enemy_Pool.ReturnObject(this);
        }
    }
    IEnumerator EnemyReturn()
    {
        yield return new WaitForSeconds(DestroyTime);
        Enemy_Pool.ReturnObject(this);
    }
}
