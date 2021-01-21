using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public bool isBeatingShield = true;

    public GameObject hitEffect;
    public float damage = 5f;

    int soundIndex;

    public static readonly string[] peas = { "Pea5", "Pea6", "Pea7", "Pea8", "Pea9", "Pea10"};

    void Start () 
    {
        Peas();
    }

    void Update () 
    {
        Destroy (this.gameObject, 5);
    }

    void OnColliderEnter2D(Collider2D col)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        /*Healthbar player = hitInfo.GetComponent<Healthbar>();
        if (player != null)
        {
            player.TakeShieldDamage(damage);
        } */
        if (col.tag == "Player")
        {
            col.SendMessage((isBeatingShield) ? "TakeShieldDamage" : "DoNothing", Time.deltaTime * damage);
        }

        Destroy(effect, 5f);
        Destroy(gameObject, 1f);
    }

    public void Peas () {
        for (int i = 0 ; i < 1 ; i++) {
            soundIndex = Random.Range(0,peas.Length);
            FindObjectOfType<AudioManager>().Play(peas[soundIndex]);
        }   
    }

}
