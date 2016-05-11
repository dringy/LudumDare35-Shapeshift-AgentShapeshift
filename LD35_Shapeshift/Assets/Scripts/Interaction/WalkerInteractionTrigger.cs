using UnityEngine;
using System.Collections;

//Designed to stop the character walking when interacting with it
public class WalkerInteractionTrigger : InteractionTrigger
{
    public Walk walk;

    public override void Interact()
    {
        FrozenWalksManager.frozenWalksManager.freezeWalk(walk);
        base.Interact();
    }
}
