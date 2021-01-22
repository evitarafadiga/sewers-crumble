using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int currentSkinIndex = 0;
    public int currency = 0;
    public int skinAvailability = 1;
    public int emeralds = 0;
    public int currentSaveState = 0;
    public string currentPlayerName;
    public int hitPoints = 0;
    public int shieldPoints = 0;

    bool gameHasEnded = false;
    public float restartDelay = 2f;

    public GameObject replayButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("HitPoints"))
        {
            // sessão prévia
            currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
            currency = PlayerPrefs.GetInt("Currency");
            emeralds = PlayerPrefs.GetInt("Emeralds");
            skinAvailability = PlayerPrefs.GetInt("SkinAvailability");
            currentSaveState = PlayerPrefs.GetInt("SaveState");
            currentPlayerName = PlayerPrefs.GetString("PlayerName");
            hitPoints = PlayerPrefs.GetInt("HitPoints");
            shieldPoints = PlayerPrefs.GetInt("Shield");

        }
        else
        {
            hitPoints = 150;

            Save();
        }

    }

    public void Save()
    {
        SaveSystem.SavePlayer(this);

        PlayerPrefs.SetInt("CurrentSkin", currentSkinIndex);
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetInt("Emeralds", emeralds);
        PlayerPrefs.SetInt("SkinAvailability", skinAvailability);
        PlayerPrefs.SetInt("SaveState", currentSaveState);
        PlayerPrefs.SetString("PlayerName", currentPlayerName);
        PlayerPrefs.SetInt("HitPoints", hitPoints);
        PlayerPrefs.SetInt("Shield", shieldPoints);

        Debug.Log("Game saved.");

    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentSkinIndex = data.currentSkinIndex;
        currency = data.currency;
        skinAvailability = data.skinAvailability;
        emeralds = data.emeralds;
        currentSaveState = data.currentSaveState;
        currentPlayerName = data.currentPlayerName;
        hitPoints = data.hitPoints;
        shieldPoints = data.shieldPoints;

        SceneManager.LoadScene(currentSaveState);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;


    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;
            Invoke("Restart", restartDelay);

        }
    }

    void Restart()
    {
        //SceneManager.LoadScene("SavedScenes");
    }

}