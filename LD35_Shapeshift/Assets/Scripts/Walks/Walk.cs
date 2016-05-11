using UnityEngine;
using System.Collections;

//Allows moveable scene parts to move in a set pattern
public class Walk : MonoBehaviour {
    public Vector2[] translationVectors; //Each line vector for every stage in the walk
    public float speed = 2f; //Speed of walking
    public bool autoTrigger = false; //Does the walking path trigger instantly
    public bool autoLoop = false; //Does the path loop once it has finished
    public Transform target; //The gameobject that is moved

    private bool isMoving;
    private int walkingVectorIndex; //Which line the walk is at
    private Vector2 destinationVector; //The point in which the direction is changing

    //Callback for when the walk is finished
    private EventReactor finishEventCallback;
    private string callbackMessage;

    void Start()
    {
        isMoving = autoTrigger;
        walkingVectorIndex = 0;
        destinationVector = new Vector2(target.transform.position.x, target.transform.position.y) + translationVectors[0];
    }

    void Update()
    {
        if (isMoving)
        {
            //Translate the subject
            Vector2 previousPosition = new Vector2(target.transform.position.x, target.transform.position.y);
            target.Translate((translationVectors[walkingVectorIndex] * Time.deltaTime * speed) / translationVectors[walkingVectorIndex].magnitude);

            //If we have made negative progress jump to the destination
            if (Vector2.Distance(previousPosition, destinationVector) < Vector2.Distance(previousPosition, new Vector2(target.transform.position.x, target.transform.position.y)))
            {
                target.transform.position = destinationVector;

                if (++walkingVectorIndex >= translationVectors.Length)
                {
                    walkingVectorIndex = 0;
                    //When we finish, we can auto loop
                    if (!autoLoop)
                    {
                        isMoving = false;

                        if (finishEventCallback != null)
                        {
                            finishEventCallback.triggerReaction(callbackMessage);
                            finishEventCallback = null;
                            callbackMessage = null;
                        }

                        return;
                    }
                }

                destinationVector = new Vector2(target.transform.position.x, target.transform.position.y) + translationVectors[walkingVectorIndex];
            }
        }
    }

    //Activates the walk
    public void Move(EventReactor callback = null, string message = null)
    {
        finishEventCallback = callback;
        callbackMessage = message;
        destinationVector = new Vector2(target.transform.position.x, target.transform.position.y) + translationVectors[0];
        isMoving = true;
    }

    //Freezes the walk
    public void Freeze()
    {
        isMoving = false;
    }

    //Unfreezes the walk
    public void Unfreeze()
    {
        isMoving = true;
    }
}
