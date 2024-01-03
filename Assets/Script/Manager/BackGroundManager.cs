using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject Background;
    public float Speed;
    float offset_y;

    void Update()
    {
        offset_y += Speed * Time.deltaTime;

        Vector2 offset = new Vector2(0, offset_y);
        Background.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }
}
