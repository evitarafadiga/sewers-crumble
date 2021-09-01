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

}
