using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBotMovement : MonoBehaviour
{
    public ArrayList visitedNodes;

    public BotNode nextNode;

    public float speed = 1f;

    public float turningSpeed = 10f;

    public bool running;

    new private Rigidbody rigidbody;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();

        if(!running){
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        visitedNodes = new ArrayList();
    }

    void Update(){
        
    }

    public void setRunning(bool _running){
        running = _running;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void OnTriggerEnter(Collider col){
        BotNode bn = col.gameObject.GetComponent<BotNode>();

        if(bn != null){
            if(bn.nextBotNode != null && !visitedNodes.Contains(bn.nextBotNode)){
                Debug.Log("Touched " + bn.gameObject.name + " from " + bn.gameObject.transform.parent.gameObject.name);
                visitedNodes.Add(bn);
                nextNode = bn.nextBotNode;
            }
        }
    }

    void FixedUpdate(){
        if(running){
            Vector3 targetDir = nextNode.transform.position - transform.position;
            
            float rotationAngle = Vector3.SignedAngle(targetDir.normalized, transform.forward, Vector3.up)/180;
            Debug.Log(rotationAngle);
            if(Mathf.Abs(1-rotationAngle) > 0.05f){
                transform.Rotate(Vector3.up, rotationAngle * turningSpeed);
            }

            transform.Translate(targetDir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
