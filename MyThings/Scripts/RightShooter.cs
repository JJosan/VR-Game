using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightShooter : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] InputActionAsset playerControls;

    private int currentlyInMotion = 0;

    InputAction RightGrapple;
    private float RightGripInput;

    InputAction RightReel;
    private float RightTriggerInput;


    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrapplable;
    public Transform gunTip, item, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    private int hitObject = 0;
    private int Boosto = 0;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Grapple");

        RightGrapple = gameplayActionMap.FindAction("ThrowRightGrapple");
        RightGrapple.performed += OnRightGrappleInput;
        RightGrapple.canceled += OnRightGrappleInput;
        RightGrapple.Enable();

        RightReel = gameplayActionMap.FindAction("ReelRightGrapple");
        RightReel.performed += OnRightReelInput;
        RightReel.canceled += OnRightReelInput;
        RightReel.Enable();

    }

    private void OnRightGrappleInput(InputAction.CallbackContext context)
    {
        RightGripInput = context.ReadValue<float>();
    }

    private void OnRightReelInput(InputAction.CallbackContext context)
    {
        RightTriggerInput = context.ReadValue<float>();
    }

    private void Update()
    {
        // throwing out web

        if (RightGripInput > 0 && currentlyInMotion == 0)
        {
            StartGrapple();
        }
        else if (RightGripInput == 0)
        {
            StopGrapple();
        }
        if (RightTriggerInput > 0 && hitObject == 1 && Boosto == 1)
        {
            Boosto = 0;
            float distance = (grapplePoint - item.position).magnitude;
            Vector3 direction = (grapplePoint - item.position) / distance;
            rb.AddForce(direction * 20, ForceMode.Impulse);
        }

    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(item.position, item.forward, out hit, maxDistance, whatIsGrapplable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);


            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;

            currentlyInMotion = 1;
            hitObject = 1;
            Boosto = 1;
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Boosto = 0;
        currentlyInMotion = 0;
        hitObject = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint)
        {
            return;
        }
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

}
