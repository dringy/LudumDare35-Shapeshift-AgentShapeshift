using UnityEngine;
using System.Collections;

//An interactable object that reports an interaction request to a given EventReactor
public class InteractionTrigger : InteractableEntity
{
    public EventReactor eventReactor;
    public string reactionString;

    public override void Interact()
    {
        eventReactor.triggerReaction(reactionString);
    }
}
