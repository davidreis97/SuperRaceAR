using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Way{Input,Output,Both}

public class CollisionController : MonoBehaviour
{
    public TrackController trackController;
    
    public Way validWay;

    public Orientation orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(trackController != null){
            Orientation newRoadOrientation = collision.gameObject.GetComponent<CollisionController>().orientation;

            Debug.Log("Creating new Road [" + collision.collider.transform.parent.name + "] with orientation " + newRoadOrientation);
            //TODO - Check Valid Way
            trackController.OnNewTrack(collision.collider.transform.parent.name, orientation, newRoadOrientation);
        }
    }
}
