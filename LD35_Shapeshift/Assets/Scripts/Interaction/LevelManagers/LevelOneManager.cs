using UnityEngine;
using System.Collections;
using System;

//Level 1 Bespoke
public class LevelOneManager : LevelManager {
    public Door FrontDoor;
    public Shapeshifter shapeshifter;

    public Vector2 FrankDefaultLocation; //Where Frank starts from
    public GameObject Frank;
    public Walk FrankToDoorWalk;
    public Walk FrankFromDoorWalk;
    public Walk FrankToGardenWalk;
    private bool IsFrankDistracted = false; //True when the magazine is ripped up

    public GameObject ScrapsContainer; //Magazine scraps
    public GameObject player;

    public override void React()
    {
        //Interacting with the door
        if (callbackString.Equals("FrontDoor"))
        {
            Options options;
            options.leftOption = "Open";
            options.rightOption = "Unlock";
            options.topOption = "Knock";
            options.bottomOption = "Admire Woodwork";
            options.reactor = this;
            options.responsePrefix = "FrontDoor";

            MessageManager.messageManager.QueueMessageWithOptions("", "It's a door!", options);
        }
        //Door answer 1
        else if (callbackString.Equals("FrontDoorOpen"))
        {
            if (IsAboveDoor())
            {
                FrontDoor.Open();
            }
            else
            {
                MessageManager.messageManager.QueueMessage("", "The door won't budge it seems to autolock when it closes.");
            }
        }
        //Door answer 2
        else if (callbackString.Equals("FrontDoorUnlock"))
        {
            MessageManager.messageManager.QueueMessage("", "You don't seem to have a key, you tried using your finger but you don't have one.");
        }
        //Door answer 3
        else if (callbackString.Equals("FrontDoorAdmire Woodwork"))
        {
            MessageManager.messageManager.QueueMessage("", "On close inspection it looks like a 4 year old drew it in Microsoft Paint");
        }
        //Door answer 4
        else if (callbackString.Equals("FrontDoorKnock"))
        {
            if (IsAboveDoor())
            {
                MessageManager.messageManager.QueueMessage("", "You knock on the door! You realise the stupidity of your actions.");
            }
            else
            {
                PlayerController.IsFrozen = true;
                Frank.transform.position = FrankDefaultLocation;
                FrankToDoorWalk.Move(this, "DoorKnockFrankArrive");
            }
        }
        //When Frank has finished walking to the door
        else if (callbackString.Equals("DoorKnockFrankArrive"))
        {
            //Depends on the appearance
            if (shapeshifter.spriteName.Equals("Emily"))
            {
                MessageManager.messageManager.SetCallback(this, "FrankLetIn");
                MessageManager.messageManager.QueueMessage("Frank", "Emily! Why are you knocking? Oh you forgot your key. Okay come on in.");
            }
            else if (shapeshifter.spriteName.Equals("Dog"))
            {
                MessageManager.messageManager.SetCallback(this, "FrankLetIn");
                MessageManager.messageManager.QueueMessage("Frank", "Dog! You can knock! Good boy, do you want a treat?");
            }
            else if (shapeshifter.spriteName.Equals("Frank"))
            {
                MessageManager.messageManager.SetCallback(this, "FrankLetIn");
                MessageManager.messageManager.QueueMessage("Frank", "Hello me! What are you doing out there get in here!");
            }
            else
            {
                MessageManager.messageManager.SetCallback(this, "FrankReject");
                MessageManager.messageManager.QueueMessage("Frank", "Who are you?! No my fridge isn't running! Go Away!");
            }
            FrontDoor.Open();
            PlayerController.IsFrozen = false;
        }
        //When speaking with emily
        else if (callbackString.Equals("Emily"))
        {
            Debug.Log("Sprite Name is: " + shapeshifter.spriteName);
            if (shapeshifter.spriteName.Equals("Emily"))
            {
                MessageManager.messageManager.SetCallback(this, "EmilyFree");
                MessageManager.messageManager.QueueMessage("Emily", "Wow! You look just like me!");
            }
            else if (shapeshifter.spriteName.Equals("Dog"))
            {
                MessageManager.messageManager.SetCallback(this, "EmilyFree");
                MessageManager.messageManager.QueueMessage("Emily", "Hello Boy fancy joining me for my run?");
            }
            else if (shapeshifter.spriteName.Equals("Frank"))
            {
                MessageManager.messageManager.SetCallback(this, "EmilyFree");
                MessageManager.messageManager.QueueMessage("Emily", "You left the hosue? Are you ill?");
            }
            else
            {
                MessageManager.messageManager.SetCallback(this, "EmilyFree");
                MessageManager.messageManager.QueueMessage("Emily", "Hello stranger, are you lost? Nothing around here except my home.");
            }
        }
        //When Emily has finished speaking
        else if (callbackString.Equals("EmilyFree"))
        {
            FrozenWalksManager.frozenWalksManager.unfreezeAllWalks();
        }
        //When frank rejects the player to enter the house
        else if (callbackString.Equals("FrankReject"))
        {
            FrontDoor.Close();
            FrankFromDoorWalk.Move();
        }
        //When frank lets the player inside
        else if (callbackString.Equals("FrankLetIn"))
        {
            FrankFromDoorWalk.Move();
        }
        //When the player interacts with the bush in the back garden
        else if (callbackString.Equals("Bush"))
        {
            const string bushExamineText = "There appears to be a large collection of questionable magazines in an envelope addressed to Frank. It would be a shame if this material was shredded across the lawn.";

            if (shapeshifter.spriteName.Equals("Dog"))
            {
                Options options;
                options.leftOption = "Rip To Shreads";
                options.rightOption = "Leave alone";
                options.topOption = "";
                options.bottomOption = "";
                options.reactor = this;
                options.responsePrefix = "Bush";

                MessageManager.messageManager.QueueMessageWithOptions("", bushExamineText, options);
            }
            else
            {
                MessageManager.messageManager.QueueMessage("", bushExamineText);
            }
        }
        //When the player chooses to rip the magazine up
        else if (callbackString.Equals("BushRip To Shreads"))
        {
            MessageManager.messageManager.QueueMessage("", "Uh oh! It would be a shame if Emily saw this.");
            PlayerController.IsFrozen = true;
            ScrapsContainer.SetActive(true);
            FrankToGardenWalk.Move(this, "FrankArriveGarden");
        }
        //When the player chooses not to
        else if (callbackString.Equals("BushLeave alone"))
        {
            MessageManager.messageManager.QueueMessage("", "You left it alone.");
        }
        //When frank finishes walking to the garden
        else if (callbackString.Equals("FrankArriveGarden"))
        {
            PlayerController.IsFrozen = false;
            MessageManager.messageManager.QueueMessage("Frank", "Nooo! Dog! I'm going to get in trouble! I have to clear all this up now!");
            IsFrankDistracted = true;
        }
        //When the player interacts with the Gem
        else if (callbackString.Equals("Gem"))
        {
            if (IsFrankDistracted)
            {
                CameraGrabber.cameraGrabber.EndGame();
            }
            else
            {
                MessageManager.messageManager.QueueMessage("Frank", "Hey! Leave that alone!");
            }
        }
        else
        {
            Debug.Log(callbackString);
        }
    }

    //Used to determine which side of the door the player is
    private bool IsAboveDoor()
    {
        return (player.transform.position.y > FrontDoor.transform.position.y);
    } 
}
