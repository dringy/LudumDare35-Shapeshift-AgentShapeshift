using UnityEngine;
using System.Collections;

//Represents an appearance that the player can shape-shift into
public class ShiftableAppearance : MonoBehaviour {
    public Sprite appearance; //The sprite to morph into
    public string appearanceName; //The name for use by the level managers
}
