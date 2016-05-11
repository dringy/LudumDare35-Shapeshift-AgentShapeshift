using UnityEngine;
using System.Collections.Generic;

//Manages the player's ability to die and respawn
public class PlayerRespawnManager : MonoBehaviour {
    public static PlayerRespawnManager respawnManager; //static verson

    public Vector2 respawnPosition; //the location to teleport the player to on respawn
    public Transform player;

    private List<GameObject> objectsToRespawn; //gameobjects to reactivate on death

	void Awake()
    {
        respawnManager = this;
        objectsToRespawn = new List<GameObject>();
    }

    public void Respawn()
    {
        //on respawn change the player's position
        player.position = respawnPosition;

        //reactivated destroyed objects
        foreach(GameObject objectToRespawn in objectsToRespawn)
        {
            objectToRespawn.SetActive(true);
        }
    }

    public void KillRespawnableEntity(GameObject entity)
    {
        //Deactivates and registers it for futrue reactivation
        entity.SetActive(false);
        objectsToRespawn.Add(entity);
    }
}