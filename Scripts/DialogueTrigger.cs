using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject enterText;
    public GameObject dialogueBox;

    void Start()
    {
        enterText.SetActive(false);
        dialogueBox.SetActive(false);
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            enterText.SetActive(true);
            if (Input.GetButtonDown("Use"))
            {
                dialogueBox.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
