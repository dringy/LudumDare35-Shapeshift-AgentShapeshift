using UnityEngine;
using System.Collections;

//A generic manager for a level
public abstract class LevelManager : EventReactor
{
    protected bool needsReacting = false;
    protected string callbackString = "";

    //Reacts on the next frame if needed
    void Update()
    {
        if (needsReacting)
        {
            React();
            needsReacting = false;
        }
    }

    //When a level manager is called it registeres the event to be called next frame
    public override void triggerReaction(string reactionString)
    {
        needsReacting = true;
        callbackString = reactionString;
    }

    //How the level manager reacts depends on the level
    abstract public void React();
}
 
