using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool isDamaging;
    public bool isBeating;

    public float damage = 10;

    private void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
            col.SendMessage((isBeating) ? "TakeShieldDamage" : "HealShieldDamage", Time.deltaTime * damage);
        }
    }
}
