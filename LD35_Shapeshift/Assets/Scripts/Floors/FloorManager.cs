using UnityEngine;
using System.Collections;

//Manages which floor is currently being used
public class FloorManager : MonoBehaviour {
    public GameObject[] floors;
    public int floorNumber;

	// Use this for initialization
	void Start () {
        floors[floorNumber].SetActive(true);
	}
	
	public void switchFloor(int nextFloorNumber)
    {
        //Activates and deactivates parent gameobjects
        floors[floorNumber].SetActive(false);
        floorNumber = nextFloorNumber;
        floors[floorNumber].SetActive(true);
    }
}
