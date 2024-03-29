﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBotMovement : MonoBehaviour
{
    public float speed = 1f;
    public float turningSpeed = 10f;
    public bool running;

    public ArrayList visitedNodes;
    public BotNode nextNode;
    new private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (!running)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        visitedNodes = new ArrayList();
    }

    void FixedUpdate()
    {
        if (running)
        {
            Vector3 targetDir = nextNode.transform.position - transform.position;

            float rotationAngle = Vector3.SignedAngle(targetDir.normalized, transform.forward, Vector3.up) / 180;
            if (Mathf.Abs(1 - rotationAngle) > 0.05f)
            {
                transform.Rotate(Vector3.up, rotationAngle * turningSpeed);
            }

            transform.Translate(targetDir.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetRunning(bool _running)
    {
        running = _running;

        if (running)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        BotNode bn = col.gameObject.GetComponent<BotNode>();

        if (bn != null)
        {
            if (bn.nextBotNode != null && !visitedNodes.Contains(bn.nextBotNode))
            {
                visitedNodes.Add(bn);
                nextNode = bn.nextBotNode;
            }
        }
        else if (col.gameObject.tag == "Track Segment" && running)
        {
            this.transform.SetParent(col.gameObject.transform, true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
