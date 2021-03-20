using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
  
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    void Start()
    {

    }

    public void Update ()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
            
        {
            Debug.Log("ECHAPE");

            if (GameIsPaused)
            {
                Resume();
            }
            
            else
            {
                Pause();
            }
        }
    }

   public void Resume()
    {
       
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    public void Pause()
    {
        Debug.Log("je suis dans pause()");
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    
}
    