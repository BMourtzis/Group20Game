using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour
{
    bool paused;
    Canvas canvas;

	// Use this for initialization
	void Start ()
    {
        paused = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log(paused);
            paused = !paused;
            StartMenu();
        }
	}

    void StartMenu()
    {
        if(paused)
        {
            Time.timeScale = 0;
            canvas.enabled = !canvas.enabled;
        }
        else
        {
            Time.timeScale = 1;
            canvas.enabled = !canvas.enabled;
        }
    }
}
