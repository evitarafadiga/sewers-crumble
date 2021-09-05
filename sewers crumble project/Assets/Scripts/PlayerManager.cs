using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake ()
    {
    	instance = this;
    	//FindObjectOfType<AudioManager>().StartFade("Theme", 5.7f, 0f);
        //FindObjectOfType<AudioManager>().Stop("Theme");
    }

    #endregion

    public GameObject player;
}
