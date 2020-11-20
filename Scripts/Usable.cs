using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Usable : MonoBehaviour
{
    public GameObject enterLevelText;
    public string levelToLoad;


    public bool dialogueTrigger = false;
    public bool loadLevelTrigger = false;
    public bool loadLockedLevelTrigger = false;
    public Dialogue dialogue;
    public GameObject enterDialogueText;
    public GameObject dialogueBox;

    void Start()
    {
        enterLevelText.SetActive(false);
        enterDialogueText.SetActive(false);
        dialogueBox.SetActive(false);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            if (loadLevelTrigger == true)
            {
                enterLevelText.SetActive(true);

            }
            else if (dialogueTrigger == true)
            {
                enterDialogueText.SetActive(true);

            }
        }
    }
    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            if (loadLevelTrigger == true)
            {
                enterLevelText.SetActive(false);
            }
            else if (enterDialogueText == true)
            {
                enterDialogueText.SetActive(false);
            }
        }
    }

    public void Use()
    {
        if (loadLevelTrigger == true)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        else if (enterDialogueText == true)
        {
            dialogueBox.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }
}
