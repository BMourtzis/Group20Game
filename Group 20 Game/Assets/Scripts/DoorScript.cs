using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    int key;
    [SerializeField]
    Sprite newDoorSprite;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<Inventory>().putKey(key))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = newDoorSprite;
        }
    }
}
