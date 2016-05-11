using UnityEngine;
using System.Collections;
using System;

//Level 3 bespoke
public class LevelThreeManager : LevelManager
{
    public CameraGrabber cameraGrabber;
    public Vector2 checkpointPosition; //Where the player respawns

    public override void React()
    {
        const string gemName = "Gem";
        const string checkpointName = "Checkpoint";

        switch (callbackString)
        {
            //When the player interacts with the gem
            case gemName:
                {
                    cameraGrabber.EndGame();
                    break;
                }
            //When the player reaches the checkpoint, change the respawn location
            case checkpointName:
                {
                    PlayerRespawnManager.respawnManager.respawnPosition = checkpointPosition;
                    break;
                }
            default:
                {
                    Debug.Log(callbackString);
                    break;
                }
        }
    }
}
