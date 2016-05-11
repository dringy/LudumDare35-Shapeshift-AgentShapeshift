using UnityEngine;
using System.Collections;

//Used in level three to kill and respawn a player on collision
public class PlayerKiller : MonoBehaviour
{
    private Collider2D entityCollider;
    void Start()
    {
        entityCollider = this.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /**
            If the player is smaller or the same size than the PlayerKiller than the player respawns, otherwise if the player is bigger then the PlayerKiller is killed.
            A minimun size difference is used to stop small differences in causing the player not to die.
        */
        const float minimunSizeDiference = 0.5f;

        if (other.tag.Equals("player"))
        {
            if ( (other.bounds.size.magnitude > entityCollider.bounds.size.magnitude) && ((other.bounds.size.magnitude - entityCollider.bounds.size.magnitude) > minimunSizeDiference))
            {
                PlayerRespawnManager.respawnManager.KillRespawnableEntity(this.gameObject);
            }
            else
            {
                PlayerRespawnManager.respawnManager.Respawn();
            }
        }
    }
}
