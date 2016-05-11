using UnityEngine;
using System.Collections;

//Manages the player
public class Shapeshifter : MonoBehaviour {
    public Sprite defaultSprite;
    public string spriteName = "Default";
    private SpriteRenderer spriteRenderer;
    public BoxCollider2D playerCollider;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //The player can press X to shift back into the default form
    void Update()
    {
        if (!MessageManager.messageManager.IsDisplaying && !PlayerController.IsFrozen)
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                ChangeSprite(defaultSprite, "Default", playerCollider);
            }
        }
    }

    //Shapeshift into a new sprite
    public void ChangeSprite(Sprite sprite, string name, BoxCollider2D collisionBox)
    {
        spriteRenderer.sprite = sprite;
        spriteName = name;
        playerCollider.offset = collisionBox.offset;
        playerCollider.size = collisionBox.size;
    }
}
