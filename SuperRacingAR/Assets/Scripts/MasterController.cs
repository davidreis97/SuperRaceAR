using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    TrackController[,] mapGrid = new TrackController[255,255];
    public GameObject definitiveStraight;
    public GameObject definitiveCurveRightSmall;
    public GameObject definitiveCurveLeftSmall;


    // Start is called before the first frame update
    void Start()
    {
        mapGrid[127,127] = gameObject.GetComponent<TrackController>(); //Add start block to grid
        mapGrid[127,127].SetGridPos(new Vector2Int(127,127));
        mapGrid[127,127].SetOrientation(Orientation.UP);

        Debug.Log(CombineOrientation(Orientation.DOWN,Orientation.DOWN));
    }

    public string getTrackName(Vector2Int gridPos){
        return "Target_Straight";
        //return "Track_" + gridPos.x + "_" + gridPos.y;
    }

    public bool OnNewTrack(string newTrack, Vector2Int newGridPos, Orientation newRoadOrientation){
        if(mapGrid[newGridPos.x,newGridPos.y] == null){
            GameObject newTrackObj;
            Quaternion orientationQuat = Quaternion.identity;

            orientationQuat *= Quaternion.Euler(0,90 * (int) newRoadOrientation,0);

            switch(newTrack){
                case "Target_Straight":
                    newTrackObj = definitiveStraight;
                    break;
                case "Target_CurveRightSmall":
                    newTrackObj = definitiveCurveRightSmall;
                    break;
                case "Target_CurveLeftSmall":
                    newTrackObj = definitiveCurveLeftSmall;
                    break;
                default:
                    Debug.LogError("Unknown track [" + newTrack + "]");
                    return false;
            }

            newTrackObj = Instantiate(newTrackObj,new Vector3(newGridPos.x-127,0,newGridPos.y-127),orientationQuat);
            newTrackObj.name = getTrackName(newGridPos);
            newTrackObj.transform.parent = gameObject.transform;
            mapGrid[newGridPos.x,newGridPos.y] = newTrackObj.GetComponent<TrackController>();
            mapGrid[newGridPos.x,newGridPos.y].enabled = true;
            mapGrid[newGridPos.x,newGridPos.y].SetGridPos(newGridPos);
            mapGrid[newGridPos.x,newGridPos.y].SetOrientation(newRoadOrientation);
            mapGrid[newGridPos.x,newGridPos.y].SetCollisionFixed();
            return true;
        }else{
            Debug.Log("Duplicate Track Detected and Not Added");
        }

        return false;
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

