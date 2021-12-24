using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    InputAction LeftJump;
    InputAction RightJump;
    private Rigidbody rb;
    private float RightInput;
    private float LeftInput;

    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default");

        LeftJump = gameplayActionMap.FindAction("JumpLeft");
        LeftJump.performed += OnJumpRightInput;
        LeftJump.canceled += OnJumpRightInput;
        LeftJump.Enable();

        RightJump = gameplayActionMap.FindAction("JumpRight");
        RightJump.performed += OnJumpLeftInput;
        RightJump.canceled += OnJumpLeftInput;
        RightJump.Enable();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RightInput > 0f)
        {
            //rb.AddForce(rb.transform.up * ThrustForce, ForceMode.Impulse);
            rb.AddForce(-0.2f, 0.5f, 0, ForceMode.Impulse);
        }

        if (LeftInput > 0f)
        {
            //rb.AddForce(rb.transform.up * ThrustForce, ForceMode.Impulse);
            rb.AddForce(0.2f, 0.5f, 0, ForceMode.Impulse);
        }
    }

    private void OnJumpRightInput(InputAction.CallbackContext context)
    {
        RightInput = context.ReadValue<float>();
    }

    private void OnJumpLeftInput(InputAction.CallbackContext context)
    {
        LeftInput = context.ReadValue<float>();
    }

}
