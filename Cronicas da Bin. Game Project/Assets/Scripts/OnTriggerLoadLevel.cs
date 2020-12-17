using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour
{

    public GameObject enterLevelText;
    public string levelToLoad;

    void Start()
    {
        enterLevelText.SetActive(false);

    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            enterLevelText.SetActive(true);
            if (Input.GetButtonDown("Use"))
            {
                Debug.Log("Entering...");
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            enterLevelText.SetActive(false);
        }

    }
}
