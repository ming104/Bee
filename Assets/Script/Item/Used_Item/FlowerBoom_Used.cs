using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBoom_Used : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroyobj());
    }

    IEnumerator Destroyobj()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(this.gameObject);
    }
}
