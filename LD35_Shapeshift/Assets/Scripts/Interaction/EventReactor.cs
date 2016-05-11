using UnityEngine;
using System.Collections;

//Represents an object that can react to an event given a simple string
public abstract class EventReactor : MonoBehaviour {
    public abstract void triggerReaction(string reactionString);
}
