using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnTriggerLoadLockedScene : MonoBehaviour
{
   	public GameObject enterText;
   	public GameObject inputinho;
   	public InputField field;
    public string levelToLoad;
    public string password;

    void Start()
    {
        enterText.SetActive(false);
        inputinho.SetActive(false);
	}

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Return)) 
        {
        	if (field.text == password) 
           	{
    			SceneManager.LoadScene(levelToLoad);
            }
        }
	}

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            enterText.SetActive(true);
            
            if (Input.GetButtonDown("Use"))
            {
            	inputinho.SetActive(true);                
            }
        }
    }
    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            enterText.SetActive(false);
        }
    }
}
