using UnityEngine;
using System.Collections;

public class doublejump : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("TutorialText").GetComponent<TutorialText>().DoubleJumpTip();
        }
    }
}
