using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pool : MonoBehaviour
{
    public static Enemy_Pool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<Enemy> poolingObjectQueue = new Queue<Enemy>();

    private void Awake()
    {
        Instance = this;

        Initialize(50);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Enemy CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Enemy>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        //newObj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        return newObj;
    }

    public static Enemy GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            //obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            //newObj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            return newObj;
        }
    }

    public static void ReturnObject(Enemy obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
        obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}