using UnityEngine;
using System.Collections;

//Checkpoint - used in level three to change the player respawn point
public class Checkpoint : MonoBehaviour {

    public EventReactor eventReactor;
    public string reactionString;

    //When the player collides with the gameobject trigger the checkpoint event
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("player"))
        {
            eventReactor.triggerReaction(reactionString);
        }
    }
}
