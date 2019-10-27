using System.Collections;
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

    private GameObject target_start;
    void Awake()
    {
        originalSpeed = speed;
        originalTurnSpeed = turnSpeed;
        carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.maxAngularVelocity = 10;
        carRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        screenTouch = GetComponent<ScreenTouch>();
        target_start = GameObject.Find("target_Start");
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

    private void FixedUpdate()
    {
        if(running){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }
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
