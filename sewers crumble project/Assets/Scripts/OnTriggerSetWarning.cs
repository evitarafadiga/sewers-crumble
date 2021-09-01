using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerSetWarning : MonoBehaviour
{
    public GameObject warning;
    public string levelToLoad;
    public int index;

    void Start()
    {
        warning.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            warning.SetActive(true);
            if (Input.GetButtonDown("Use"))
            {
            	if (levelToLoad == "")
                {
                    if (index != 0)
            	    SceneManager.LoadScene(index);

                    SceneManager.LoadScene(GameManager.Instance.currentSaveState);
                }

                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            warning.SetActive(false);
        }

    }
}
