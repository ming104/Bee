using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePlane : Item
{
    [SerializeField] private GameObject BeePlane_Prefab;

    public override void usedItem(Transform trans)
    {
        var item_prefab = Instantiate(BeePlane_Prefab);
        item_prefab.transform.position = trans.position;
    }
}
