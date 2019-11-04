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

    private bool outOfBounds;

    private GameObject current_track;

    void Awake()
    {
        originalSpeed = speed;
        originalTurnSpeed = turnSpeed;
        carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.maxAngularVelocity = 10;
        screenTouch = GetComponent<ScreenTouch>();

        current_track = GameObject.Find("target_Start");
        carRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        //powerInput = Input.GetAxis("Vertical"); //Not being used since car always moves forward
        turnInput = screenTouch.GetInput() + Input.GetAxis("Horizontal");

        //Set gravity to follow the track's orientation
        Physics.gravity = -current_track.transform.up;
    }

    private void FixedUpdate()
    {
        if (running)
        {
            float finalSpeed = speed;
            if (outOfBounds)
            {
                finalSpeed *= 0.2f;
            }
            transform.Translate(Vector3.back * finalSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, turnInput * turnSpeed);
            //carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }
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
            current_track = other.gameObject;
        }
        else if (other.gameObject.tag == "Out of Map")
        {
            outOfBounds = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Debug.Log("COLLIDING PLAYER: " + GetComponent<Collider>());
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
