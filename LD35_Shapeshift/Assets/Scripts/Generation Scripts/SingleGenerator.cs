using UnityEngine;
using System.Collections;

//Generates a single given prefab in a given position
public class SingleGenerator : Generator {
    public GameObject prefabToGenerate;
    public Vector2 position;

    public override void Generate()
    {
        InstanciatePrefab(prefabToGenerate, position);
    }
}
