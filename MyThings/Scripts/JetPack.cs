using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{

    private Rigidbody rb;
    private float ThrustForce = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0f)
        {
            rb.AddForce(rb.transform.up * ThrustForce, ForceMode.Impulse);
        }

        
    }
}
