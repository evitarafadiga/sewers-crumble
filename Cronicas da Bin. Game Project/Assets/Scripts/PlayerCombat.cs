using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    IsometricCharacterRenderer isoRenderer;

    public Transform attackPoint;
    public LayerMask enemyLayer;
    public LayerMask usableLayer;
    public LayerMask hitboxLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 30;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    protected virtual void Awake()
    {
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    public void CallAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
            StartCoroutine(EndAttack());

        }
    }

    public void CallUse()
    {
        if (Time.time >= nextAttackTime)
        {
            Use();
            nextAttackTime = Time.time + 1f / attackRate;

        }
    }

    public void Use()
    {
        Collider2D[] hitUsables = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, usableLayer); 

        foreach (Collider2D usable in hitUsables)
        {
            usable.GetComponent<Usable>().Use();
        }
    }

    public void Attack()
    {
        isoRenderer.isAttacking = true;
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        //Collider2D[] hitBoxes = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hitboxLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        /*
        foreach (Collider2D hitbox in hitBoxes)
        {
            hitbox.GetComponent<Hitbox>().TakeDamage(attackDamage);
        }
        */

    }

    private IEnumerator EndAttack()
    {

        yield return new WaitForSeconds(0.60f);
        isoRenderer.isAttacking = false;

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Footsteps()
    {
        FindObjectOfType<AudioManager>().Play("FootstepsCommon");
    }
}
