using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

//Grabs the camera to a black space and gives the intro and closing text
public class CameraGrabber : EventReactor {
    public CameraFollow cameraFollow; //The camera follow to activate/deactivate
    public Text BigText; //The large ui text

    public string introBigText; //The introduction big text
    public string exitBigText; //The ending big text

    public string[] missionbriefing; //Lines for the briefing
    public string[] missionending; //Lines for the closing message

    public static CameraGrabber cameraGrabber; //Static member

    public int nextLevelNumber; //The next level to load

    void Awake()
    {
        cameraGrabber = this;
    }

	void Start()
    {
        //Move the camera to the black space
        cameraFollow.transform.position = this.transform.position;

        //Set up the intro text and messages
        BigText.text = introBigText;
        BigText.gameObject.SetActive(true);
        MessageManager.messageManager.SetCallback(this, "StartLevel");
        MessageManager.messageManager.QueueMessages("Sgt. Meta", missionbriefing);
    }

    public void EndGame()
    {
        //Stop the camera and move the camera to black space
        cameraFollow.StopFollow();
        cameraFollow.transform.position = this.transform.position;

        //Set up the closing text and messages
        BigText.text = exitBigText;
        BigText.gameObject.SetActive(true);
        MessageManager.messageManager.SetCallback(this, "EndLevel");
        MessageManager.messageManager.QueueMessages("Sgt. Meta", missionending);
    }

    public override void triggerReaction(string reactionString)
    {
        if (reactionString.Equals("StartLevel"))
        {
            //Turn off the text
            BigText.gameObject.SetActive(false);
            //Move the camera back
            cameraFollow.transform.position = cameraFollow.subject.transform.position;
            //Set the follow on
            cameraFollow.Follow();
        }
        else
        {
            //Load the next scene after the end
            SceneManager.LoadScene(nextLevelNumber);
        }
    }
}
