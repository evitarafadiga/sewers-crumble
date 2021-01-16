using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HitboxDef : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 150;
    public int currentHealth;
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
            animator.Play("DeathEffect");
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }

}
