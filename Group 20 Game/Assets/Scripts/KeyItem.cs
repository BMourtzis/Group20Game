using UnityEngine;
using System.Collections;

public class KeyItem : MonoBehaviour
{
    [SerializeField]
    [Range(0,4)]
    int key;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().getKey(key);
            Destroy(gameObject);
        }
    }
}
