using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGuard : Item
{
    [SerializeField] private GameObject FlowerGuard_Prefab;
    public override void usedItem(Transform trans)
    {
        var item_prefab = Instantiate(FlowerGuard_Prefab);
        item_prefab.transform.position = trans.position;
    }
}
