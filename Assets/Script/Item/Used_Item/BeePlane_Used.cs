using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePlane_Used : MonoBehaviour
{
    [SerializeField] private float Speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroyobj());
    }

    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    IEnumerator Destroyobj()
    {
        yield return new WaitForSeconds(25f);
        Destroy(this.gameObject);
    }
}
