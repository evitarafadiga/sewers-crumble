using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitbox : MonoBehaviour
{
    public Animator animator;

	public float currentHealth;
	private float maxHealth = 150;
	private bool wasOpen = false;

    void Start()
    {
    	if (wasOpen == false)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
            {
                wasOpen = true;
            }
        }      
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        float ratio = currentHealth / maxHealth;

    	if (ratio*100 >= 80)
    	animator.Play("A");
    	else if (ratio*100 >= 60)
    	animator.Play("B");
    	else if (ratio*100 >= 40)
    	animator.Play("C");
    	else if (ratio*100 >= 20)
    	animator.Play("D");   	
    	else if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        wasOpen = true;
        this.gameObject.SetActive(false);
        animator.Play("DeathEffect");
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        if (wasOpen == true)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SavedPositionManager.savedPositions[sceneIndex] = transform.position;
        }      
    }
}
