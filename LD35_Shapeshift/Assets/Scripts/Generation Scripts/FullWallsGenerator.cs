using UnityEngine;

//All eight wall assets
[System.Serializable]
public struct WallSet
{
    public GameObject northWall;
    public GameObject eastWall;
    public GameObject southWall;
    public GameObject westWall;
    public GameObject northEasthWall;
    public GameObject southEastWall;
    public GameObject southWestWall;
    public GameObject northWesthWall;
}

//Signifies where a hole in the wall should be
[System.Serializable]
public struct WallHole
{
    public float startOfHole;
    public float endOfHole; //in number of wall tiles units
}

//All the holes in each of the four walls
[System.Serializable]
public struct WallHoleCollection
{
    public WallHole[] northWallHoles;
    public WallHole[] southWallHoles;
    public WallHole[] eastWallHoles;
    public WallHole[] westhWallHoles;
}

//Indicates which walls to draw
[System.Serializable]
public struct WallDrawConfig
{
    public bool DrawNorth;
    public bool DrawSouth;
    public bool DrawEast;
    public bool DrawWest;
}

//Generates four walls with corner
public class FullWallsGenerator : Generator
{
    public WallSet wallPrefabsToGenerate;
    public Vector2 bottomLeftCorner;
    public Vector2 topRightCorner;

    public WallHoleCollection wallHoles;
    public WallDrawConfig wallConfig;

    public override void Generate()
    {
        //Check size is posotive
        Debug.Assert(topRightCorner.x >= bottomLeftCorner.x);
        Debug.Assert(topRightCorner.y >= bottomLeftCorner.y);

        //Draw south west and north east walls
        if (wallConfig.DrawSouth && wallConfig.DrawWest)
        {
            InstanciatePrefab(wallPrefabsToGenerate.southWestWall, bottomLeftCorner);
        }

        if (wallConfig.DrawNorth && wallConfig.DrawEast)
        {
            InstanciatePrefab(wallPrefabsToGenerate.northEasthWall, topRightCorner);
        }

        //Draw south east and north west walls
        if (wallConfig.DrawSouth && wallConfig.DrawEast)
        {
            InstanciatePrefab(wallPrefabsToGenerate.southEastWall, topRightCorner.x, bottomLeftCorner.y);
        }

        if (wallConfig.DrawNorth && wallConfig.DrawWest)
        {
            InstanciatePrefab(wallPrefabsToGenerate.northWesthWall, bottomLeftCorner.x, topRightCorner.y);
        }

        bool shouldDrawWall = true;

        //Draw in the north and south wall
        for (float xPos = bottomLeftCorner.x + 1f; xPos < topRightCorner.x; ++xPos)
        {
            //South
            if (wallConfig.DrawSouth)
            {
                shouldDrawWall = true;
                foreach (WallHole hole in wallHoles.southWallHoles)
                {
                    if ((xPos >= hole.startOfHole) && (xPos < hole.endOfHole))
                    {
                        shouldDrawWall = false;
                        break;
                    }
                }

                if (shouldDrawWall)
                {
                    InstanciatePrefab(wallPrefabsToGenerate.southWall, xPos, bottomLeftCorner.y);
                }
            }
      
            //North
            if (wallConfig.DrawNorth)
            {
                shouldDrawWall = true;
                foreach (WallHole hole in wallHoles.northWallHoles)
                {
                    if ((xPos >= hole.startOfHole) && (xPos < hole.endOfHole))
                    {
                        shouldDrawWall = false;
                        break;
                    }
                }

                if (shouldDrawWall)
                {
                    InstanciatePrefab(wallPrefabsToGenerate.northWall, xPos, topRightCorner.y);
                }
            }
        }

        //Draw east and west walls
        for (float yPos = bottomLeftCorner.y + 1f; yPos < topRightCorner.y; ++yPos)
        {
            //West
            if (wallConfig.DrawWest)
            {
                shouldDrawWall = true;
                foreach (WallHole hole in wallHoles.westhWallHoles)
                {
                    if ((yPos >= hole.startOfHole) && (yPos < hole.endOfHole))
                    {
                        shouldDrawWall = false;
                        break;
                    }
                }

                if (shouldDrawWall)
                {
                    InstanciatePrefab(wallPrefabsToGenerate.westWall, bottomLeftCorner.x, yPos);
                }
            }

            //East
            if (wallConfig.DrawEast)
            {
                shouldDrawWall = true;
                foreach (WallHole hole in wallHoles.eastWallHoles)
                {
                    if ((yPos >= hole.startOfHole) && (yPos < hole.endOfHole))
                    {
                        shouldDrawWall = false;
                        break;
                    }
                }

                if (shouldDrawWall)
                {
                    InstanciatePrefab(wallPrefabsToGenerate.eastWall, topRightCorner.x, yPos);
                }
            }
        }

        if (drawCollider)
        {
            float centreX = (bottomLeftCorner.x + topRightCorner.x) / 2;
            float centreY = (bottomLeftCorner.y + topRightCorner.y) / 2;
            Vector2 sizex = new Vector2(topRightCorner.x - bottomLeftCorner.x, tileSize);
            Vector2 sizey = new Vector2(tileSize, topRightCorner.y - bottomLeftCorner.y);

            //South
            AddCollider(new Vector2(centreX, bottomLeftCorner.y + (tileSize / 2.0f) ), sizex);
            //North
            AddCollider(new Vector2(centreX, topRightCorner.y - (tileSize / 2.0f)), sizex);
            //East
            AddCollider(new Vector2(topRightCorner.x - (tileSize / 2.0f), centreY), sizey);
            //West
            AddCollider(new Vector2(bottomLeftCorner.x + (tileSize / 2.0f), centreY), sizey);
        }
    }
}
