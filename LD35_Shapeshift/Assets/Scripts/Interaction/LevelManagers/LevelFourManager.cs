using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

//Level 4 bespoke code
public class LevelFourManager : LevelManager
{
    public override void React()
    {
        const string sgtName = "Sgt";

        switch (callbackString)
        {
            //When speaking with the sergeant
            case sgtName:
                {
                    string[] sgtSpeech =
                    {
                        "Hello shapeshifter, welcome back!",
                        "I'm sorry to say this, but I lied to you.",
                        "Let me explain, 1000 years ago demons ran loose across the land.",
                        "A powerful warlock sealed them away by burning three magical gems.",
                        "That warlock created three spares in case we needed to reseal the lock.",
                        "Due to recent earthquakes the locks has come loose, it's time to reseal it.",
                        "However 43 years one of the magical gems was destroyed in a volcano by evil-doers.",
                        "The only way to seal the demons is for you shapeshifter, to shapeshift into one of the gems.",
                        "However upon activation all gems including you will die.",
                        "If the demons escape, millions could die. Humanity, and by extention, you could survive the war.",
                        "So I have to give you an option, sacrifice yourself for humanity, or hope to survive in a demon filled world.",
                        "I'm sorry to give you this option so late in our quest, but I wanted your honest gut feeling to be the only factor involved.",
                        "I cannot make this decision for you. So what will it be?"
                    };

                    Options options;
                    options.bottomOption = "";
                    options.topOption = "";
                    options.leftOption = "Save Humanity";
                    options.rightOption = "Save Yourself";
                    options.reactor = this;
                    options.responsePrefix = "Outcome";

                    MessageManager.messageManager.QueueMessagesWithOptions("Sgt.Meta", sgtSpeech, options);

                    break;
                }
            //When choosing to save humanity
            case "OutcomeSave Humanity":
                {
                    MessageManager.messageManager.SetCallback(this, "EndGame");
                    MessageManager.messageManager.QueueMessage("Sgt.Meta", "On behalf of humanity we apologise for your fate, we thank you for the ability to live on.");
                    break;
                }
            //When choosing to save yourself
            case "OutcomeSave Yourself":
                {
                    MessageManager.messageManager.SetCallback(this, "EndGame");
                    MessageManager.messageManager.QueueMessage("Sgt.Meta", "I understand, we have rough road a head of us then, it's time for humanity to face it's destiny.");
                    break;
                }
            //After the sergeant says the final message
            case "EndGame":
                {
                    SceneManager.LoadScene(4);
                    break;
                }
            default:
                {
                    Debug.Log(callbackString);
                    break;
                }
        }
    }
}
