using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    Animator animator;
    private float gripTarget;
    //private float triggerTarget;
    private float gripCurrent;
    //private float triggerCurrent;
    [SerializeField] private float animationSpeed;
    private string animatorGripParam = "Grip";
    //private string animatorTriggerParam = "Trigger";


    //[SerializeField] private GameObject followObject;
    //[SerializeField] private float followSpeed = 30f;
    //[SerializeField] private float rotateSpeed = 100f;
    //[SerializeField] private Vector3 positionOffset;
    //[SerializeField] private Vector3 rotationOffset;

    //private Transform _followTarget;
    //private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //_followTarget = followObject.transform;
        //_body = GetComponent<Rigidbody>();
        //_body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        //_body.interpolation = RigidbodyInterpolation.Interpolate;
        //_body.mass = 20f;

        //_body.position = _followTarget.position;
        //_body.rotation = _followTarget.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
        //PhysicsMove();
    }

    // copy of a working version

    //void PhysicsMove()
    //{
    //    var positionWithOffset = _followTarget.TransformPoint(positionOffset);
    //    var distance = Vector3.Distance(positionWithOffset, transform.position);
    //    _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

    //    var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
    //    var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
    //    q.ToAngleAxis(out float angle, out Vector3 axis);
    //    if (angle > 180)
    //    {
    //        angle -= 360;
    //    }
    //    _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);


    //}


    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    //internal void SetTrigger(float v)
    //{
    //    triggerTarget = v;
    //}

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        //if (triggerCurrent != triggerTarget)
        //{
        //    triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
        //    animator.SetFloat(animatorTriggerParam, triggerCurrent);
        //}
    }
}
