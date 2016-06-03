using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    int key;
    Sprite newDoorSprite ;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if(other.GetComponent<Inventory>().putKey(key))
            {
                Destroy(gameObject.GetComponent<Collider>());
                gameObject.GetComponent<SpriteRenderer>().sprite = newDoorSprite;
            }
        }
    }
}
