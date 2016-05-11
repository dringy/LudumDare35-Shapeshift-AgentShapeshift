using UnityEngine;
using System.Collections;
using System;

//Line direction
public enum LineDirection
{
    Horizontal, Vertical
}

public class LineGenerator : Generator {
    public GameObject prefabToGenerate; //The gameobject to generate in a line
    public LineDirection lineDirection;
    public Vector2 startPoint;
    public int lineLength = 5; //in gameobjects to generate

    public override void Generate()
    {
        Debug.Assert(lineLength != 0);
        int iterateDirection = (lineLength > 0) ? 1 : -1;

        //horizontal
        if (lineDirection == LineDirection.Horizontal)
        {
            for (int tileNo = 0; tileNo < Mathf.Abs(lineLength); ++tileNo)
            {
                InstanciatePrefab(prefabToGenerate, startPoint + new Vector2(tileNo * iterateDirection, 0f));
            }
        }
        //vertical
        else
        {
            for (int tileNo = 0; tileNo < Mathf.Abs(lineLength); ++tileNo)
            {
                InstanciatePrefab(prefabToGenerate, startPoint + new Vector2(0f, tileNo * iterateDirection));
            }
        }
    }
}
