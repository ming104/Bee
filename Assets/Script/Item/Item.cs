using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void usedItem(Transform transform);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound("Item_Eat");
            usedItem(GameObject.Find("Bee").transform);
            Destroy(this.gameObject);
        }
    }
}