using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
    private const float rotationSpeed = 0.2f; 

	// Update is called once per frame
	void Update () {
        //Rotate to point to mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleToRotate = Mathf.Atan2(mousePosition.y - this.transform.position.y, mousePosition.x - this.transform.position.x) * Mathf.Rad2Deg;
        this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(0.0f, 0.0f, angleToRotate), rotationSpeed);
    }
}
