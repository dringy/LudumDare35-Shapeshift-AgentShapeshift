using UnityEngine;
using System.Collections;

//A component that allows the player to interact with InteractableEntity scene objects
public class Interactor : MonoBehaviour {
    public Shapeshifter shapeShifter; //The player shapeshift componnent

    public Sprite CannotShapeShiftSprite; //The interaction sprite for when there is no option for shape shifting
    public Sprite CanShapeShiftSprite; //The interaction sprite for when there is a scene object that allows shapeshifting
    private SpriteRenderer spriteRenderer; //The sprite renderer for the interaction arrow

    private Collider2D interactionSubject; //The subject currently in range of the interaction
    private InteractableEntity grabbedSubject; //A subject that may have stolen attention from the interactor
    private bool isGrabbed = false; //Is the atention being stolen?

    private Collider2D shiftableSubject;

    //Instanciate
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CannotShapeShiftSprite;
    }

    //Called every frame
    void Update()
    {
        //If attention is being stolen check if something is in range
        if (!isGrabbed && (shiftableSubject != null))
        {
            //If the subject is out of shiftable range or is inactive just forget about it
            if (!shiftableSubject.bounds.Intersects(this.GetComponent<Collider2D>().bounds) || !shiftableSubject.gameObject.activeSelf)
            {
                if (shiftableSubject.Equals(interactionSubject))
                {
                    ClearAll();
                }
                else
                {
                    ClearShiftable();
                }
            }
        }

        //If the player is frozen don't respond to interactions
        if (!PlayerController.IsFrozen)
        {
            //Interact with entity
            if (Input.GetMouseButtonUp(0))
            {
                if (isGrabbed)
                {
                    grabbedSubject.Interact();
                }
                else if (interactionSubject != null)
                {
                    //If the subject is out of interaction range or is inactive just forget about it
                    if (!interactionSubject.bounds.Intersects(this.GetComponent<Collider2D>().bounds) || !interactionSubject.gameObject.activeSelf)
                    {
                        if (interactionSubject.Equals(shiftableSubject))
                        {
                            ClearAll();
                        }
                        else
                        {
                            ClearInteractor();
                        }
                    }
                    else
                    {
                        InteractableEntity interactableEntity = interactionSubject.GetComponent<InteractionTrigger>();

                        //Assumption is only enforced here that tag and component are paired
                        Debug.Assert(interactableEntity != null);

                        interactableEntity.Interact();
                    }
                }
            }
            //Shapeshift into subject
            else if (Input.GetMouseButtonUp(1))
            {
                if (shiftableSubject != null)
                {
                    ShiftableAppearance shiftableAppearance = shiftableSubject.GetComponent<ShiftableAppearance>();

                    shapeShifter.ChangeSprite(shiftableAppearance.appearance, shiftableAppearance.appearanceName, shiftableAppearance.GetComponent<BoxCollider2D>());
                }
            }
        }
    }

    //Register interactable and shiftable scene objects as being in range
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("interactable"))
        {
            interactionSubject = other;
        }

        ShiftableAppearance shiftableAppearance = other.GetComponent<ShiftableAppearance>();
        if (shiftableAppearance != null)
        {
            shiftableSubject = other;
            spriteRenderer.sprite = CanShapeShiftSprite;
        }
    }

    //de-register interactable and shiftable scene objects as being in range
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.Equals(interactionSubject))
        {
            ClearInteractor();
        }

        if (other.gameObject.Equals(shiftableSubject))
        {
            ClearShiftable();
        }
    }

    //null the interactable subject in view
    public void ClearInteractor()
    {
        interactionSubject = null;
    }

    //null the shiftable subject in view
    public void ClearShiftable()
    {
        shiftableSubject = null;
        spriteRenderer.sprite = CannotShapeShiftSprite;
    }

    //null the interactable subject and shiftable subject in view
    public void ClearAll()
    {
        ClearInteractor();
        ClearShiftable();
    }

    //Steal attention
    public void GrabAttention(InteractableEntity grabber)
    {
        grabbedSubject = grabber;
        isGrabbed = true;
    }

    //Release attention
    public void ReleaseGrab(InteractableEntity grabber)
    {
        if (grabbedSubject.Equals(grabber))
        {
            grabbedSubject = null;
            isGrabbed = false;
        }
    }
}
