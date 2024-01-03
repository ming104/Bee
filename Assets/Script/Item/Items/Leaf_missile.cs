using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_missile : Item
{
    [SerializeField] private GameObject Leaf_missile_Prefab;

    public override void usedItem(Transform trans)
    {
        var item_prefab = Instantiate(Leaf_missile_Prefab);
        item_prefab.transform.position = trans.position;
    }
}
