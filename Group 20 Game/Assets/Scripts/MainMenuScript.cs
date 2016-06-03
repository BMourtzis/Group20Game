using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    Canvas LevelCanvas;

    Canvas canvas;

	// Use this for initialization
	void Start ()
    {
        canvas = GetComponent<Canvas>();
        LevelCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Cancel"))
        {
            
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
        canvas.enabled = true;
        LevelCanvas.enabled = false;
    }
}
