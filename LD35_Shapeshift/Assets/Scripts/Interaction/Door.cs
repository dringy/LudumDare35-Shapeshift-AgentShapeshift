using UnityEngine;
using System.Collections;

//Represents an in-game door
public class Door : MonoBehaviour {
    public bool isOpen;
    public Sprite openDoorSprite; //the sprite of the door when it's open
    public Sprite closedDoorSprite; //the sprite of the door when it's closed

    private BoxCollider2D boxCollider; //the collider of the door which we turn off when open
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Assert(boxCollider != null);
        Debug.Assert(spriteRenderer != null);

        UpdateDoorStatus();
	}
	
    //Updates the door sprite and deactivates/activates the collider
	private void UpdateDoorStatus()
    {
        spriteRenderer.sprite = isOpen ? openDoorSprite : closedDoorSprite;
        boxCollider.enabled = !isOpen;
    }

    //Opens the door
    public void Open()
    {
        isOpen = true;
        UpdateDoorStatus();
    }

    //Closes the door
    public void Close()
    {
        isOpen = false;
        UpdateDoorStatus();
    }

    public void ToggleDoorState()
    {
        isOpen = !isOpen;
        UpdateDoorStatus();
    }
}
