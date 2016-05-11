using UnityEngine;
using System.Collections;

//Represents stairs joining two different floors
public class Stairs : MonoBehaviour {
    public FloorManager floorManager; //Manages the different floors
    public LineDirection direction; //The direction the stairs go
    //Indicates what floors are connect and which way round (e.g north-south or south-north)
    public int posotiveFloor = 1;
    public int negativeFloor = 0;

    void OnTriggerExit2D(Collider2D other)
    {
        //Only react to the player
        if (other.tag.Equals("player"))
        {
            //Line direction indicates if we look at x or y, swith the floors when the player leaves the central collider
            if (direction == LineDirection.Horizontal)
            {
                if (this.transform.position.x < other.transform.position.x)
                {
                    floorManager.switchFloor(posotiveFloor);
                }
                else
                {
                    floorManager.switchFloor(negativeFloor);
                }
            }
            else
            {
                if (this.transform.position.y < other.transform.position.y)
                {
                    floorManager.switchFloor(posotiveFloor);
                }
                else
                {
                    floorManager.switchFloor(negativeFloor);
                }
            }
        }
    }
}
