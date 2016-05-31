using UnityEngine;
using System.Collections;

public class tutorialgun : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("TutorialText").GetComponent<TutorialText>().UseGunTip();
        }
    }
}
