using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
	public bool isTrap;
    public bool isDamaging;
    public bool isBeatingShield;
    public bool isBuffingHp;
    public bool isBuffingShield;
    public bool isSubtle;
    public bool addKeyLevel;
    public bool addCoin;

    public float damage = 10;

    public Animator trapAnimator;
    public Animator foundKey;
    public GameObject gob;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (isSubtle == false)
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (isSubtle == true) 
            {
                if (addKeyLevel == true)
                {
                    col.SendMessage((addKeyLevel) ? "AddKey" : "DoNothing");
                    if(foundKey.gameObject.activeSelf)
                    	foundKey.SetTrigger("KeyFound");
                    gameObject.SetActive(false);
                }
                else if (addCoin == true)
                {
                    col.SendMessage((addCoin) ? "AddCoin" : "DoNothing");
                    gameObject.SetActive(false);
                }
                else
                {
                    int i = (int) damage;

                    while (i > 0)
                    {
                    col.SendMessage((isDamaging) ? "TakeDamage" : "DoNothing", damage);
                    col.SendMessage((isBeatingShield) ? "TakeShieldDamage" : "DoNothing", damage);
                    col.SendMessage((isBuffingHp) ? "HealDamage" : "DoNothing", damage);
                    col.SendMessage((isBuffingShield) ? "HealShieldDamage" : "DoNothing", damage);
                    i--;
                    }
                }                
            }
            if (isTrap == true)
            {
               	trapAnimator.SetTrigger("Bite");
               	gob.SetActive(false);
            }
        }
    }
}
