using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSound : MonoBehaviour
{
	private Queue<string> themeSounds;

    void Start()
    {
       themeSounds = new Queue<string>(); 
    }

    public void StartTheme(Dialogue dialogue)
    {

        themeSounds.Clear();

        foreach (string sounds in dialogue.sentences)
        {
            themeSounds.Enqueue(sounds);
        }

        PlayNextTheme();
    }

    void PlayNextTheme()
    {
    	if (themeSounds.Count == 0)
        {
            return;
        }

        string sounds = themeSounds.Dequeue();
        StartCoroutine(PlaySound(sounds));
    }

    IEnumerator PlaySound(string sounds)
    {
        FindObjectOfType<AudioManager>().Play(sounds);
        yield return null;
    }
}
