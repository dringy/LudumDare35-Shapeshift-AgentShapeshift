using UnityEngine;
using System.Collections;

//Controls the player
public class PlayerController : MonoBehaviour {
    public static bool IsFrozen = false; //Boolean allows the player to be frozen

    private const float speed = 5f; //Speed of movement

    void Awake()
    {
        IsFrozen = false;
    }

	// Update is called once per frame
	void Update () {
        //If the player isn't frozen and there are no messages being displayed then move the player based on input controls (using Translate)
	    if (!MessageManager.messageManager.IsDisplaying && !IsFrozen)
        {
            Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
            this.transform.Translate(moveVector);
        }
        //Guard against unwanted rotation
        this.transform.localRotation = Quaternion.identity;
	}
}
