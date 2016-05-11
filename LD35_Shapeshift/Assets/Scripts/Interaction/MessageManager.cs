using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Options for displaying multiple choice answers
public struct Options
{
    //Up to four options
    public string topOption;
    public string bottomOption;
    public string leftOption;
    public string rightOption;
    //The reactor who recieves the response
    public EventReactor reactor;
    //The reactor is given this prefix and the option text as the event string
    public string responsePrefix;
}

//Allows other components to display messages and answers
public class MessageManager : InteractableEntity
{
    public static MessageManager messageManager;

    //Every message has a name and main message, for when nobody is speaking the name is empty
    private struct Message
    {
        public string messageText;
        public string name;
    }
    //List of messages to display on screen
    private List<Message> messages;

    public Text messageTextUI; // for the messageText of the message
    public Text nameUI; // for the name of the message
    public Interactor interactor; // the interactor for the player

    public bool IsDisplaying = false; //Are messages being displayed?

    //Options
    public Options options;
    private bool IsOptionsSet = false; //Are answer options being displayed
    public GameObject optionsContainer; //Parent GameObject for easy activation/deactivation
    
    //Options buttons
    public Button TopButton;
    public Button BottomButton;
    public Button LeftButton;
    public Button RightButton;

    //Callback
    private EventReactor callback; //recieves a trigger when the messages finish
    private string callbackMessage;

    void Awake()
    {
        this.gameObject.SetActive(false); //turn off the messages by default after first initialising
        messages = new List<Message>();
        messageManager = this;
    }

    //Add a message to be displayed
    public void QueueMessage(string name, string messageText)
    {
        Message message;
        message.name = name;
        message.messageText = messageText;

        messages.Add(message);

        DisplayMessage();
    }

    //Add multiple messages to be displayed
    public void QueueMessages(string name, string[] messageTexts)
    {
        foreach(string message in messageTexts)
        {
            QueueMessage(name, message);
        }
    }

    //Add a message to be displayed with answer options
    public void QueueMessageWithOptions(string name, string messageText, Options inOptions)
    {
        options = inOptions;
        IsOptionsSet = true;
        QueueMessage(name, messageText);
    }

    //Add multiple messages to be displayed with answer options
    public void QueueMessagesWithOptions(string name, string[] messageTexts, Options inOptions)
    {
        options = inOptions;
        IsOptionsSet = true;
        QueueMessages(name, messageTexts);
    }

    //Set the callback to be triggered when messages finish
    public void SetCallback(EventReactor ercallback, string message)
    {
        callback = ercallback;
        callbackMessage = message;
    }

    //Interactions cause the next message to be displayed, or if there isn't one the UI gets turned off, the player is allowed to move and the callback is triggered
    public override void Interact()
    {
        if (messages.Count > 0)
        {
            messages.RemoveAt(0); //we always display message 0 so by removing the message at index 0 we cause the next message to be displayed.

            if (messages.Count > 0)
            {
                DisplayMessage();
                return;
            }
        }

        if (IsOptionsSet)
        {
            DisplayOptions();
            return;
        }

        if (callback != null)
        {
            callback.triggerReaction(callbackMessage);
            callback = null;
            callbackMessage = null;
        }

        IsDisplaying = false;
        this.gameObject.SetActive(false);
        interactor.ReleaseGrab(this);
    }

    private void DisplayMessage()
    {
        IsDisplaying = true;
        messageTextUI.text = messages[0].messageText;
        nameUI.text = messages[0].name;
        interactor.GrabAttention(this);
        this.gameObject.SetActive(true);
    }

    //Display the answer options
    private void DisplayOptions()
    {
        //An empty option is classed as not needing a button.
        if (options.topOption.Equals(""))
        {
            TopButton.gameObject.SetActive(false);
        }
        else
        {
            TopButton.GetComponentInChildren<Text>().text = options.topOption;
            TopButton.gameObject.SetActive(true);
        }

        if (options.bottomOption.Equals(""))
        {
            BottomButton.gameObject.SetActive(false);
        }
        else
        {
            BottomButton.GetComponentInChildren<Text>().text = options.bottomOption;
            BottomButton.gameObject.SetActive(true);
        }

        if (options.leftOption.Equals(""))
        {
            LeftButton.gameObject.SetActive(false);
        }
        else
        {
            LeftButton.GetComponentInChildren<Text>().text = options.leftOption;
            LeftButton.gameObject.SetActive(true);
        }

        if (options.rightOption.Equals(""))
        {
            RightButton.gameObject.SetActive(false);
        }
        else
        {
            RightButton.GetComponentInChildren<Text>().text = options.rightOption;
            RightButton.gameObject.SetActive(true);
        }

        this.gameObject.SetActive(true);
        optionsContainer.SetActive(true);
    }

    //Called by clicking the option, it sends the answer choice back to the reactor
    public void SelectOption(Text inUIText)
    {
        optionsContainer.SetActive(false);
        IsOptionsSet = false;
        options.reactor.triggerReaction(options.responsePrefix + inUIText.text); //prefix is used for clarifying it is a user selected answer
    } 
}
