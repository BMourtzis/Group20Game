using UnityEngine;
using System.Collections;

public class BossFightScript : MonoBehaviour
{
    [SerializeField]
    GameObject wall;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            wall.GetComponent<SpriteRenderer>().enabled = true;
            wall.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
