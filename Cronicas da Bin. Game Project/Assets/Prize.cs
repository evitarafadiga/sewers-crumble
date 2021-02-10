using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{

	public bool isDamaging;
    public bool isBeatingShield;
    public bool isBuffingHp;
    public bool isBuffingShield;

	public float damage = 10;

    void Action(CircleCollider2D circle)
    {
        int i = (int) damage;
        while (i > 0)
        {
            circle.SendMessage((isDamaging) ? "TakeDamage" : "DoNothing", damage);
            circle.SendMessage((isBeatingShield) ? "TakeShieldDamage" : "DoNothing", damage);
            circle.SendMessage((isBuffingHp) ? "HealDamage" : "DoNothing", damage);
            circle.SendMessage((isBuffingShield) ? "HealShieldDamage" : "DoNothing", damage);
            i--;
        }
    } 
}
