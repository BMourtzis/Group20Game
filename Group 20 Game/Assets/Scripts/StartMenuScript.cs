using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField]
    Canvas LevelCanvas;

    bool paused;
    bool onLevel;
    Canvas canvas;

	// Use this for initialization
	void Start ()
    {
        paused = false;
        onLevel = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        LevelCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Cancel"))
        {
            if (onLevel)
            {
                Back();
            }
            else
            {
                paused = !paused;
                PauseMenu();
            }
        }
	}

    void PauseMenu()
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

    public void Resume()
    {
        paused = !paused;
        PauseMenu();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else 
		Application.Quit();
#endif
    }

    public void Level()
    {
        onLevel = true;
        canvas.enabled = false;
        LevelCanvas.enabled = true;
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void Back()
    {
        onLevel = false;
        canvas.enabled = true;
        LevelCanvas.enabled = false;
    }
}
