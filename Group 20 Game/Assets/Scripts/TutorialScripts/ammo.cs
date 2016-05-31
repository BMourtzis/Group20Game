using UnityEngine;
using System.Collections;

public class ammo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("TutorialText").GetComponent<TutorialText>().AmmoPackTip();
        }
    }
}
