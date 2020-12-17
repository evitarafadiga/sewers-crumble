using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject enterDialogueText;
    public GameObject dialogueBox;

    void Start()
    {
        enterDialogueText.SetActive(false);
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
            enterDialogueText.SetActive(true);
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
            enterDialogueText.SetActive(false);
        }
    }

}
