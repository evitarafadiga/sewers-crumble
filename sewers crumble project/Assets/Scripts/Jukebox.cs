using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jukebox : MonoBehaviour
{
	public Dialogue dialogue;

	void Start()
	{
		FindObjectOfType<ThemeSound>().StartTheme(dialogue);
	}

	void OnDestroy() {
		Stop();
	}

	void Stop()
    {
        foreach (string sounds in dialogue.sentences)
        {
            FindObjectOfType<AudioManager>().Stop(sounds);
        }
    }

}
