using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Bullet : Item
{
    [SerializeField] private Bee_Bullet_Used Bullet;

    void Start()
    {
        Bullet = GameObject.Find("Bullet_Shooter").GetComponent<Bee_Bullet_Used>();
    }

    public override void usedItem(Transform trans)
    {
        Bullet.StartFire(trans);
    }
}
