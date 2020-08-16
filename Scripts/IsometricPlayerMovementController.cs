using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsometricPlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Status health;

    [SerializeField]
    private Status energy;

    private float initHealth = 100;

    private float initEnergy = 120;

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    protected virtual void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    protected void Start() 
    {
        health.Initialize(initHealth,initHealth);
        energy.Initialize(initEnergy,initEnergy);
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            health.MyCurrentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            energy.MyCurrentValue -= 30;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);
        //isoRenderer.isAttacking();
        Debug.Log("done casting");
    }
  

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);

        GetInput();
    }

}
