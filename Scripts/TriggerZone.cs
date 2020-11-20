using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool isDamaging;
    public bool isBeatingShield;
    public bool isBuffingHp;
    public bool isBuffingShield;

    public float damage = 10;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "DoNothing", Time.deltaTime * damage);
            col.SendMessage((isBeatingShield) ? "TakeShieldDamage" : "DoNothing", Time.deltaTime * damage);
            col.SendMessage((isBuffingHp) ? "HealDamage" : "DoNothing", Time.deltaTime * damage);
            col.SendMessage((isBuffingShield) ? "HealShieldDamage" : "DoNothing", Time.deltaTime * damage);
        }
    }
}
