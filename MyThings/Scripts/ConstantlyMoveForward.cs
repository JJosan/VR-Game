using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyMoveForward : MonoBehaviour
{
    [SerializeField] public float speed = 5;
    [SerializeField] public Rigidbody rb;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
}
