using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bee_Bullet_Used : MonoBehaviour
{
    [SerializeField] private GameObject Beebullet;
    [SerializeField] private int BulletCount;
    [SerializeField] private float BulletSpeed;

    public void StartFire(Transform trans)
    {
        StartCoroutine(Fire(trans));
    }

    public IEnumerator Fire(Transform trans)
    {
        for (int i = 0; i < BulletCount; i++)
        {
            var BeeBullet_Prefab = Instantiate(Beebullet);
            BeeBullet_Prefab.transform.position = gameObject.transform.position;
            BeeBullet_Prefab.transform.rotation = trans.rotation;
            BeeBullet_Prefab.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * BulletSpeed, ForceMode2D.Impulse);
            Destroy(BeeBullet_Prefab, 4f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
