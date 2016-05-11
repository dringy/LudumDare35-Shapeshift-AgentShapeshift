using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform subject; //subject to follow
    private const float followSpeed = 0.15f;

    public bool followOn = false;
	
	// Update is called once per frame
	void Update () {
        if (followOn)
        {
            Debug.Assert(subject != null);
            //Follow using a Lerp
            this.transform.position = Vector3.Lerp(this.transform.position, subject.transform.position, followSpeed);
        }
	}

    public void Follow()
    {
        followOn = true;
    }

    public void StopFollow()
    {
        followOn = false;
    }
   
}
