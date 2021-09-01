using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IsometricEnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 randomMovement;
    IsometricCharacterRenderer isoRenderer;
    //public CircleCollider2D circle;
    //IsometricPlayerMovementController beatingPlayer;

    public bool nullAtkAnim = false;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        //circle = GetComponent<CircleCollider2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);// * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        isoRenderer.SetDirection(movement);
    }

    private void FixedUpdate() {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
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

    private void Attack()
    {
        if (nullAtkAnim == true) 
        return;
        isoRenderer.isAttacking = true;
       
    }

    private IEnumerator EndAttack()
    {

        yield return new WaitForSeconds(5.60f);
        isoRenderer.isAttacking = false;

    }

    public void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            CallAttack();
            //moveCharacter(movement);
        }

        //else
        //{
        //    moveCharacter(RandomUnitVector());
        //}
    }

    public Vector2 RandomUnitVector()
    {
        float random = Random.Range(0f, 260f);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }
}
