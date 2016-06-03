using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour
{
    public string text;
    public float timeTaken;

    Text textElement;
    float time;

    // Use this for initialization
    void Start ()
    {
        textElement = GetComponent<Text>();
        textElement.text = text;
        time = Time.time + timeTaken;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Time.time > time)
        {
            textElement.enabled = false;
        }
	}
}
