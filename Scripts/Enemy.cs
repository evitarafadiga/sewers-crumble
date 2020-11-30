using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public GameObject villain;
    public Animator animator;

    public GameObject deathEffect;

    public int maxHealth = 150;
    int currentHealth;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (isDead == false)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
            {
                transform.position = SavedPositionManager.savedPositions[sceneIndex];
            }
        }
        else
        {
            this.enabled = false;
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
        //this.enabled = false;
        //Debug.Log("Morri toda");
        //Destroy(gameObject);
        //Destroy(villain);
        villain.SetActive(false);
        //this.gameObject.SetActive(false);
        DeathEffect();
        isDead = true;
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        if (isDead == false)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SavedPositionManager.savedPositions[sceneIndex] = transform.position;
        }
        
    }

    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

}
