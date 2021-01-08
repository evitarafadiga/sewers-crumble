using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitbox : MonoBehaviour
{
	public GameObject hitBox;

	HitboxRenderer hitRenderer;

	public float currentHealth;
	//private float maxHealth = 150;
	private bool wasOpen = false;


	protected virtual void Awake ()
	{
		hitRenderer = GetComponentInChildren<HitboxRenderer>();
	}

    void Start()
    {
    	if (wasOpen == false)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
            {
                transform.position = SavedPositionManager.savedPositions[sceneIndex];
            }
        }      
        else
       	{
        hitBox.SetActive(false);
        //Destroy(hitBox);
       	}
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        hitRenderer.SetState(currentHealth);        

        if (currentHealth <= 0)
        {
            wasOpen = true;
            hitBox.SetActive(false);
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        if (wasOpen == false)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SavedPositionManager.savedPositions[sceneIndex] = transform.position;
        }       
    }
}
