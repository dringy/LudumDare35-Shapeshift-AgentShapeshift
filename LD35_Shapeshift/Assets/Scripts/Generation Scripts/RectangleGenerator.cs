using UnityEngine;
using System.Collections;

//Generates a filled rectangle of a given game object
public class RectangleGenerator : Generator
{
    public GameObject prefabToGenerate;
    public Vector2 bottomLeftCorner;
    public Vector2 topRightCorner;

    //Generate rectangle
    public override void Generate()
    {
        //Check size is posotive
        Debug.Assert(topRightCorner.x >= bottomLeftCorner.x);
        Debug.Assert(topRightCorner.y >= bottomLeftCorner.y);

        //nested iterator through x and y
        for (float xPos = bottomLeftCorner.x; xPos <= topRightCorner.x; ++xPos)
        {
            for (float yPos = bottomLeftCorner.y; yPos <= topRightCorner.y; ++yPos)
            {
                InstanciatePrefab(prefabToGenerate, xPos, yPos);
            }
        }
    }
}
