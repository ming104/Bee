//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject Player;

    [Header("EnemySpawn")]
    [SerializeField] private GameObject Enemy;

    [SerializeField] private GameObject Target;
    [SerializeField] private float Speed;

    public GameObject[] SpawnPoint;

    [SerializeField] private float SummonTime;

    [Header("ItemSpawn")]
    [SerializeField] private List<GameObject> ItemPrefabs;


    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.Find("Bee");
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnItem");
    }

    void Update()
    {

    }
    void OnEnable()
    {
        Target = GameObject.Find("Bee");
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(2, 5); i++)
            {
                var EnemyObj = Enemy_Pool.GetObject();
                int rand = Random.Range(0, SpawnPoint.Length);
                EnemyObj.GetComponent<Transform>().position = SpawnPoint[rand].transform.position;
                EnemyObj.GetComponent<Rigidbody2D>().AddForce((Target.transform.position - EnemyObj.transform.position).normalized * Speed, ForceMode2D.Impulse);

            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            int x = Random.Range(-2, 2);
            int y = Random.Range(-4, 4);
            var ItemPrefab = Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Count)]);
            ItemPrefab.transform.position = new Vector2(x, y);

            yield return new WaitForSeconds(Random.Range(5f, 20f));
        }
    }
}
