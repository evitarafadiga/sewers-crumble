using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject warning;
    public string levelToLoad;

    void Update () {
    	if (Input.GetKeyDown(KeyCode.Escape))
    	{
    		if (GameIsPaused)
    		{
    			Resume();
    		} else
    		{
    			Pause();
    		}
    	}
    }

    public void Resume ()
    {
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    void Pause () 
    {
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    public void LoadMenu()
    {
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
    	Application.Quit();
    }

    public void SaveGame()
    {
        GameManager.Instance.Save();  
    }

    public void LoadPlayer()
    {
        SaveSystem.LoadPlayer();
    }

    public void ToggleWarning()
    {
        warning.SetActive(!warning.activeSelf);
    }

    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

}
