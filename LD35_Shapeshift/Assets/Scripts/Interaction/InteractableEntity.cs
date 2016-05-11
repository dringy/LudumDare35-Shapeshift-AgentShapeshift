using UnityEngine;
using System.Collections;

//An entity that the player can go up to and interact with using player input
public abstract class InteractableEntity : MonoBehaviour {

    abstract public void Interact();
}
