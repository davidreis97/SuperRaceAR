using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 10f;
    private float originalSpeed;
    private float originalTurnSpeed;
    private float turnInput;

    private bool running;
    private bool outOfBounds;

    private Rigidbody carRigidbody;
    private ScreenTouch screenTouch;
    private GameObject currentTrack;

    void Awake()
    {
        originalSpeed = speed;
        originalTurnSpeed = turnSpeed;

        carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.maxAngularVelocity = 10;
        carRigidbody.constraints = RigidbodyConstraints.FreezeAll;

        screenTouch = GetComponent<ScreenTouch>();
        currentTrack = GameObject.Find("target_Start");
    }

    void Update()
    {
        turnInput = screenTouch.GetInput();

        // Set gravity to follow the track's orientation
        Physics.gravity = -currentTrack.transform.up;
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
        }
    }

    public void SetRunning(bool _running)
    {
        running = _running;

        if (running)
        {
            carRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            carRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Out of Map")
        {
            outOfBounds = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Track Segment" && running)
        {
            outOfBounds = false;
            currentTrack = other.gameObject;
            this.transform.SetParent(currentTrack.transform, true);
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
