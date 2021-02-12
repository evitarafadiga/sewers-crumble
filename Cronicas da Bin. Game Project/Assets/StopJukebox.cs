using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJukebox : MonoBehaviour
{
	public Dialogue dialogue;

    void Start()
    {
        foreach (string sounds in dialogue.sentences)
        {
            FindObjectOfType<AudioManager>().Stop(sounds);
        }
    }
}
