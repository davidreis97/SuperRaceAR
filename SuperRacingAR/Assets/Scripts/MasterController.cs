using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    TrackController[,] mapGrid = new TrackController[255,255];
    public GameObject definitiveStraight;
    public GameObject definitiveCurve;

    // Start is called before the first frame update
    void Start()
    {
        mapGrid[127,127] = gameObject.GetComponent<TrackController>(); //Add start block to grid
        mapGrid[127,127].SetGridPos(new Vector2Int(127,127));
        mapGrid[127,127].SetOrientation(Orientation.UP);
    }

    public string getTrackName(Vector2Int gridPos){
        return "Track_" + gridPos.x + "_" + gridPos.y;
    }

    public void OnNewTrack(string newTrack, Vector2Int newGridPos, Orientation newRoadOrientation){
        if(mapGrid[newGridPos.x,newGridPos.y] == null){
            GameObject newTrackObj;
            Quaternion orientationQuat = Quaternion.identity;

            orientationQuat *= Quaternion.Euler(0,90 * (int) newRoadOrientation,0);

            switch(newTrack){
                case "Target_Straight":
                    newTrackObj = definitiveStraight;
                    break;
                case "Target_Curve":
                    newTrackObj = definitiveCurve;
                    break;
                default:
                    Debug.LogError("Unknown track [" + newTrack + "]");
                    return;
            }

            newTrackObj = Instantiate(newTrackObj,new Vector3(newGridPos.x-127,0,newGridPos.y-127),orientationQuat);
            newTrackObj.name = getTrackName(newGridPos);
            newTrackObj.transform.parent = gameObject.transform;
            mapGrid[newGridPos.x,newGridPos.y] = newTrackObj.GetComponent<TrackController>();
            mapGrid[newGridPos.x,newGridPos.y].SetGridPos(newGridPos);
            mapGrid[newGridPos.x,newGridPos.y].SetOrientation(newRoadOrientation);
        }else{
            Debug.Log("Duplicate Track Detected and Not Added");
        }
    }

    public void OnTrackRemoved(Vector2Int gridPos){
        //Remove Definitive Track
        mapGrid[gridPos.x,gridPos.y] = null;
        Destroy(GameObject.Find(getTrackName(gridPos)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Orientation CombineOrientation(Orientation or1, Orientation or2){
        return (Orientation)(((int)or1 + (int)or2)%4);
    }
}

public enum Orientation {UP,RIGHT,DOWN,LEFT};

