﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 10f;
    private float originalSpeed;
    private float originalTurnSpeed;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;

    void Awake()
    {
        originalSpeed = speed;
        originalTurnSpeed = turnSpeed;
        carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.maxAngularVelocity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    }

    public void slowDownSpeed()
    {
        speed = speed * 0.2f;
        turnSpeed = turnSpeed * 0.5f;

    }

    public void resetSpeed()
    {
        speed = originalSpeed;
        turnSpeed = originalTurnSpeed;
    }
}
