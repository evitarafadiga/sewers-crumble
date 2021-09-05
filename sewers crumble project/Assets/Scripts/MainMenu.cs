using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject startMenu;
    public GameObject currencyMenu;

    public GameObject levelButtonPrefab;
    public GameObject levelButtonImage;
    public GameObject levelButtonContainer;
    public GameObject levelSelectionMenu;
    public GameObject newGameMenu;

    public string levelToLoad;
    public TextMeshProUGUI currencyCoinsUserInfoText;
    public TextMeshProUGUI currencyEmeraldsUserInfoText;
    public TextMeshProUGUI currencyHitPoints;
    public TextMeshProUGUI currencyShield;

    private void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Episodes");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            //container.GetComponentInChildren<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContainer.transform, false);

            GameObject billboard = Instantiate(levelButtonImage) as GameObject;
            levelButtonPrefab.transform.Find("billboard").GetComponent<Image>().sprite = thumbnail;
           	
           	container.GetComponent<Button>().onClick.AddListener(() => CheckGame(GameManager.Instance.currentSaveState));
           	
            //billboard.GetComponent<Image>().sprite = thumbnail;
            //levelButtonImage.transform.SetParent(levelButtonImage.transform, false);
            // string sceneName = thumbnail.name;
            // container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
            //container.GetComponent<Button>().onClick.AddListener(() => LoadLevelByIndex(GameManager.Instance.currentSaveState));	
        }

        currencyCoinsUserInfoText.text = GameManager.Instance.currentSaveState.ToString();
        currencyEmeraldsUserInfoText.text = GameManager.Instance.currency.ToString();
        //currencyHitPoints.text = GameManager.Instance.hitPoints.ToString();
        //currencyShield.text = GameManager.Instance.shieldPoints.ToString();

        //currencyPlayerNameInfoText.text = "Nome : " + GameManager.Instance.currentPlayerName.ToString();
    }

    void UpdateCurrencies()
    {
    	currencyCoinsUserInfoText.text = GameManager.Instance.currentSaveState.ToString();
        currencyEmeraldsUserInfoText.text = GameManager.Instance.currency.ToString();
    }

    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ShowOptionsMenu()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ToggleLevelSelection()
    {
        levelSelectionMenu.SetActive(!levelSelectionMenu.activeSelf);
    }

    public void ToggleNewGame()
    {
        newGameMenu.SetActive(!newGameMenu.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LookAtMenu()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void SaveGame()
    {
        GameManager.Instance.Save();
    }

    public void LoadPlayer()
    {
        SaveSystem.LoadPlayer();
    }

    public void NewGame()
    {
        Clean();
        SaveGame();
        LoadLevelByIndex(1);
    }

    public void ContinueGame()
    {
    	LoadLevelByIndex(GameManager.Instance.currentSaveState);

    }

    public void CheckGame(int saveState)
    {
    	if (saveState > 0) 
    	{
    		ToggleNewGame();
    	}
    	else 
    	{
    		Clean();
    		NewGame();
    	}
    }

    void Clean()
    {
        GameManager.Instance.Restart();
    }
}