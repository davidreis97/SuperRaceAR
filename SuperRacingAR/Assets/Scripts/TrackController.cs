using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrackController : MonoBehaviour
{   
    MasterController masterController;

    public CollisionController collisionController1;

    public CollisionController collisionController2;

    Orientation orientation;

    Vector2Int gridPos;

    void Start()
    {
        masterController = GameObject.Find("Target_Start").GetComponent<MasterController>();
    }

    public void SetOrientation(Orientation _orientation){
        orientation = _orientation;
    }

    public void SetGridPos(Vector2Int _gridPos){
        gridPos = _gridPos;
    }

    public void OnNewTrack(string trackName, Orientation roadOrientation, Orientation newRoadOrientation){ //Receives the name of the new track
        if(gridPos == null){
            return;
        }
        
        Orientation finalOrientation = MasterController.CombineOrientation(orientation,roadOrientation);

        Vector2Int newGridPos;

        switch(finalOrientation){
            case Orientation.UP:
                newGridPos = new Vector2Int(gridPos.x,gridPos.y + 1);
                break;
            case Orientation.RIGHT:
                newGridPos = new Vector2Int(gridPos.x + 1,gridPos.y);
                break;
            case Orientation.DOWN:
                newGridPos = new Vector2Int(gridPos.x,gridPos.y - 1);
                break;
            case Orientation.LEFT:
                newGridPos = new Vector2Int(gridPos.x - 1,gridPos.y);
                break;
            default:
                Debug.LogError("Wrong Orientation");
                return;
        }

        Debug.Log("NewGridPos: " + newGridPos + " Final Orientation: " + finalOrientation);

        masterController.OnNewTrack(trackName,newGridPos,newRoadOrientation);
    }

    void Update()
    {
        
    }
}
