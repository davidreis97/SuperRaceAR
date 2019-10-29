﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 10f;
    private float originalSpeed;
    private float originalTurnSpeed;
    //private float powerInput; //Not being used since car always moves forward
    private float turnInput;
    private Rigidbody carRigidbody;
    private ScreenTouch screenTouch;

    private bool running;

    private bool outOfBounds;

    private GameObject target_start;

    void Awake()
    {
        originalSpeed = speed;
        originalTurnSpeed = turnSpeed;
        carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.maxAngularVelocity = 10;
        screenTouch = GetComponent<ScreenTouch>();

        target_start = GameObject.Find("target_Start");
        carRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        //powerInput = Input.GetAxis("Vertical"); //Not being used since car always moves forward
        turnInput = screenTouch.GetInput() + Input.GetAxis("Horizontal");

        //Set gravity to follow the track's orientation
        Physics.gravity = -target_start.transform.up;
    }

    public void setRunning(bool _running){
        running = _running;
        carRigidbody.constraints = RigidbodyConstraints.None;
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Out of Map"){
            outOfBounds = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Track Segment")
        {
            outOfBounds = false;
            this.transform.SetParent(other.gameObject.transform, true);
        }
        else if (other.gameObject.tag == "Out of Map")
        {
            outOfBounds = true;
        }
    }

    private void FixedUpdate()
    {
        if(running){
            float finalSpeed = speed;
            if(outOfBounds){
                finalSpeed *= 0.2f;
            }
            transform.Translate(Vector3.back * finalSpeed * Time.deltaTime);
            carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }
    }
}
