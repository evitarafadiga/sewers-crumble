using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeSound : MonoBehaviour
{
	private Queue<string> themeSounds;

    public Dialogue dialogue;
    void Start()
    {
       themeSounds = new Queue<string>();
       SceneManager.activeSceneChanged += ChangedActiveScene;
       FindObjectOfType<ThemeSound>().StartTheme(dialogue);
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

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            FindObjectOfType<AudioManager>().StartFade("Theme",6,0F);
        }
    }
}
