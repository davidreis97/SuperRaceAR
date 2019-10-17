﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 30f;
    public float turnSpeed = 2f;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;

    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    }
}