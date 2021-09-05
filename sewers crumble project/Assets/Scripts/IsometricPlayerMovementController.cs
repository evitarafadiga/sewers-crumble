using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    PlayerCombat combat;

    Rigidbody2D rbody;

    public Joystick joystick;

    protected virtual void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        combat = GetComponentInChildren<PlayerCombat>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        if (Input.GetAxisRaw("Fire1") != 0) combat.CallAttack();
        if (Input.GetAxisRaw("Use") != 0) combat.CallUse();

        //Opção de Joystick
        //float horizontalInput = joystick.Horizontal;
        //float verticalInput = joystick.Vertical;

        //Original
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }
}
