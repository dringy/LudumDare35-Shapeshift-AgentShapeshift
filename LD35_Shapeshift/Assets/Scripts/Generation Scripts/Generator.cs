using UnityEngine;
using System.Collections;

//Generates some assets
public abstract class Generator : MonoBehaviour {
    public bool generateOnStart = true; //generate on start
    public bool drawCollider = false; //Draw colliders on the sprites
    public float tileSize = 1f;

    //Generate at start
    void Start()
    {
        if (generateOnStart)
        {
            Generate();
        }
    }

    //Instances a given prefab at a given position at an identity Quaternion and makes the instance a child of this transform.
    protected void InstanciatePrefab(GameObject prefabToInstance, Vector2 position, int scaleFactor = 1)
    {
        GameObject generatedTile = Instantiate(
                    prefabToInstance,
                    position * tileSize,
                    Quaternion.identity) as GameObject;
        generatedTile.transform.SetParent(this.transform);
        generatedTile.transform.localScale *= scaleFactor;
    }

    protected void InstanciatePrefab(GameObject prefabToInstance, float x, float y, int scaleFactor = 1)
    {
        InstanciatePrefab(prefabToInstance, new Vector2(x, y), scaleFactor);
    }

    //Adds a collider to the game object
    protected void AddCollider(Vector2 centre, Vector2 size)
    {
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.offset = centre;
        collider.size = size;
    }

    public abstract void Generate();
}
