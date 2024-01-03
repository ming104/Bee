using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBoom : Item
{
    [SerializeField] private GameObject FlowerBoom_Prefab;
    public override void usedItem(Transform trans)
    {
        var item_prefab = Instantiate(FlowerBoom_Prefab);
        item_prefab.transform.position = trans.position;
    }
}
