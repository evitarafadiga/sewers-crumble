using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Usable : MonoBehaviour
{
    public GameObject enterLevelText;
    public int index;

    public Animator flagAnimator;
    public Animator doorAnimator;

    public bool dialogueTrigger = false;
    public bool loadLevelTrigger = false;
    public bool loadLockedLevelTrigger = false;
    public bool saveGame = false;
    public bool isPopup = false;
    public bool isDoor = false;

    public Dialogue dialogue;
    public GameObject enterDialogueText;
    public GameObject dialogueBox;
    public GameObject popupBalloon;
    public GameObject doorCollider;

    public Animator transition;
    public float transitionTime = 1f;

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
            else if (isPopup == true)
            {
                popupBalloon.SetActive(true);
                StartCoroutine(ClosePopupBalloon());
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
            StartCoroutine(LoadLevel(index));
        }
        else if (loadLockedLevelTrigger == true)
        {
            if (GameManager.Instance.currentSaveState < SceneManager.GetActiveScene().buildIndex)
            {
                return;
            }
            
            StartCoroutine(LoadLevel(GameManager.Instance.currentSaveState));
        }
        else if (enterDialogueText == true)
        {
            dialogueBox.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else if (saveGame == true)
        {
            GameManager.Instance.Save();
            flagAnimator.Play("Trumbling");   
        }
        else if (isDoor == true)
        {
            doorAnimator.SetTrigger ("Used");
            doorCollider.SetActive(!doorCollider.activeSelf);
        }

    }

    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger ("StartAnim");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

    IEnumerator ClosePopupBalloon()
    {
        yield return new WaitForSeconds(20f);
        popupBalloon.SetActive(false);
    }
}
