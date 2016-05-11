using UnityEngine;
using System.Collections;
using System;

//Level 2 Bespoke
public class LevelTwoManager : LevelManager
{
    public Shapeshifter shapeshifter;

    public GameObject cakeObject; //The cake to be made

    public CameraGrabber cameraGrabber;

    //Who visited (disguised) the auntie
    private bool steveVisted = false;
    private bool sebastianVisited = false;
    private bool arnoldVisited = false;

    //What ingredients the player got
    private bool gotEgg = false;
    private bool gotMilk = false;
    private bool gotSugar = false;
 
    private bool madeCake = false;

    public override void React()
    {
        const string steveName = "Steve";
        const string sebastianName = "Sebastian";
        const string saphireName = "Saphire";
        const string maleChickenName = "MaleChicken";
        const string femaleChickenName = "FemaleChicken";
        const string arnoldName = "Arnold";
        const string oldWomanName = "OldWoman";
        const string sugarChildName = "Pile of Sugar";
        const string fridgeName = "Fridge";
        const string ovenName = "Oven";
        const string cakeName = "Cake";
        const string steveCakeReaction = "SteveEatCake";

        switch (callbackString)
        {
            //Talking to steve
            case steveName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case steveName:
                            {
                                MessageManager.messageManager.QueueMessage(steveName, "Who put this mirror here?.");
                                break;
                            }
                        case sebastianName:
                        case saphireName:
                        case arnoldName:
                            {

                                MessageManager.messageManager.QueueMessage(steveName, "You know I think auntie likes me because I'm honest ya know?");
                                break;
                            }
                        case maleChickenName:
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage(steveName, "mmm I'm hungry!");
                                break;
                            }
                        case oldWomanName:
                            {
                                MessageManager.messageManager.QueueMessage(steveName, "Hello Auntie, can I have some cake?");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.SetCallback(this, steveCakeReaction);
                                MessageManager.messageManager.QueueMessage(steveName, "Oh my a cake! Yum yum!");
                                break;
                            }
                        default:
                            {
                                MessageManager.messageManager.QueueMessage(steveName, "Who are you? Do you cook?");
                                break;
                            }
                    }
                    break;
                }
            //Talking to sebastian
            case sebastianName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case sebastianName:
                            {
                                MessageManager.messageManager.QueueMessage(sebastianName, "Who is this imposter?! Guards! ... We have no Guards.");
                                break;
                            }
                        case steveName:
                        case saphireName:
                        case arnoldName:
                            {

                                MessageManager.messageManager.QueueMessage(sebastianName, "Auntie likes me the best because I have sophistication. I bring our family glory.");
                                break;
                            }
                        case maleChickenName:
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage(sebastianName, "Get out vermin!");
                                break;
                            }
                        case oldWomanName:
                            {
                                MessageManager.messageManager.QueueMessage(sebastianName, "Auntie. Good to see you're well.");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage(sebastianName, "Ah! That cake looks terrible. Get away!");
                                break;
                            }
                        default:
                            {
                                MessageManager.messageManager.QueueMessage(sebastianName, "You must be one of the staff, I have no time for peasants.");
                                break;
                            }
                    }
                    break;
                }
            //Talking to Saphire
            case saphireName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case saphireName:
                            {
                                MessageManager.messageManager.QueueMessage(saphireName, "Hey good lookin', sorry couldn't resist, also why do you like exactly like me?");
                                break;
                            }
                        case sebastianName:
                        case steveName:
                        case arnoldName:
                            {

                                MessageManager.messageManager.QueueMessage(saphireName, "Auntie likes me the best because I'm the only girl, I'm there to make sure she always looks beautiful.");
                                break;
                            }
                        case maleChickenName:
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage(saphireName, "Bukay! Haha!");
                                break;
                            }
                        case oldWomanName:
                            {
                                MessageManager.messageManager.QueueMessage(saphireName, "Hey Auntie! You know purple isn't in right now.");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage(saphireName, "No thanks it would go straight to my hips!");
                                break;
                            }
                        default:
                            {
                                MessageManager.messageManager.QueueMessage(saphireName, "I love your outfit!");
                                break;
                            }
                    }
                    break;
                }
            //Talking to the male chicken
            case maleChickenName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case maleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage("Rooster", "Hey, get off my land!");
                                break;
                            }
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage("Rooster", "Look I know you're the only hen here but... I think I can do better.");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage("Rooster", "Who left this cake here?");
                                break;
                            }
                        case steveName:
                        case sebastianName:
                        case saphireName:
                        case arnoldName:
                        case oldWomanName:
                        default:
                            {
                                MessageManager.messageManager.QueueMessage("Rooster", "Cock-a-doodle-do.");
                                break;
                            }
                    }
                    break;
                }
            //Talking to the female chicken
            case femaleChickenName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case maleChickenName:
                            {
                                if (gotEgg)
                                {
                                    MessageManager.messageManager.QueueMessage("Hen", "I hope you like your present.");
                                }
                                else
                                {
                                    MessageManager.messageManager.QueueMessage("Hen", "errrm hel...hello. I...I...I got you a present. It's my egg. I hopee.... you like it.");
                                    MessageManager.messageManager.QueueMessage("", "You got an egg.");
                                    gotEgg = true;
                                }
                                
                                break;
                            }
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage("Hen", "Hey Sister! It's nice to get some girls around here once in a while.");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage("Hen", "I feel like I'm related to this cake.");
                                break;
                            }
                        case steveName:
                        case sebastianName:
                        case saphireName:
                        case arnoldName:
                        case oldWomanName:
                        default:
                            {
                                MessageManager.messageManager.QueueMessage("Hen", "Buck buck.");
                                break;
                            }
                    }
                    break;
                }
            //Talking to Arnold
            case arnoldName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case arnoldName:
                            {
                                MessageManager.messageManager.QueueMessage(arnoldName, "Wow! This is impossible! The chances you would look exactly the same is impossible. Are we twins?");
                                break;
                            }
                        case sebastianName:
                        case saphireName:
                        case steveName:
                            {

                                MessageManager.messageManager.QueueMessage(arnoldName, "Auntie likes me the best because I have the best academics. I am destined to achieve great things apparently.");
                                break;
                            }
                        case maleChickenName:
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage(arnoldName, "Hmm, I wonder if you're happy?");
                                break;
                            }
                        case oldWomanName:
                            {
                                MessageManager.messageManager.QueueMessage(arnoldName, "Hey Auntie! Thanks for having me.");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage(arnoldName, "I wonder what the chemical composition of this cake is?");
                                break;
                            }
                        default:
                            {
                                MessageManager.messageManager.QueueMessage(arnoldName, "Oh hello, I don't think We've met, I'm arnold");
                                break;
                            }
                    }
                    break;
                }
            //Talking to the Old Woman (auntie)
            case oldWomanName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case steveName:
                            {
                                if (steveVisted)
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "You are always so kind.");
                                }
                                else
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "Oh my little Steve, you always lift my mood.");
                                    steveVisted = true;
                                }
                                
                                break;
                            }
                        case sebastianName:
                            {
                                if (sebastianVisited)
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "You're mannerisms have never faulted us once.");
                                }
                                else
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "Oh Sebastian darling, you look as dashing as ever. I'm happy to see you.");
                                    sebastianVisited = true;
                                }

                                break;
                            }
                        case saphireName:
                            {
                                MessageManager.messageManager.QueueMessage(oldWomanName, "Here to complain about my outfit again? I can wear what I want. I'm upset now");
                                //reset happiness to zero
                                sebastianVisited = false;
                                steveVisted = false;
                                arnoldVisited = false;

                                break;
                            }
                        case maleChickenName:
                        case femaleChickenName:
                            {
                                break;
                            }
                        case arnoldName:
                            {
                                if (arnoldVisited)
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "I never understand what you're up to, but I'm so proud of you.");
                                }
                                else
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "Oh Arnold, you're hair looks all scruffy, you really are the brains not the beauty but you will be well known some day. I'm so happy to have you.");
                                    arnoldVisited = true;
                                }

                                break;
                            }
                        case oldWomanName:
                            {
                                MessageManager.messageManager.QueueMessage(oldWomanName, "Oh hello, you seem to have a good sense of style.");
                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage(oldWomanName, "Ooh a cake, better save it for Steve. He loves cakes!");
                                break;
                            }
                        default:
                            {
                                //happiness is higher the more visited she is
                                int happinessRaiting = (arnoldVisited ? 1 : 0) + (sebastianVisited ? 1 : 0) + (steveVisted ? 1 : 0);

                                if (happinessRaiting == 3)
                                {
                                    if (gotMilk)
                                    {
                                        MessageManager.messageManager.QueueMessage(oldWomanName, "Hello stranger, I hope you enjoy my milk, freshly milked from premium cows you know.");
                                    }
                                    else
                                    {
                                        MessageManager.messageManager.QueueMessage(oldWomanName, "Hello stranger, I'm so happy I feel like giving you a glass of milk. Here you go.");
                                        MessageManager.messageManager.QueueMessage("", "You got some Milk");
                                        gotMilk = true;
                                    }
                                }
                                else if (happinessRaiting == 2)
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "Hello stranger, You know I feel quite happy at the moment, almost in a giving mood, almost.");
                                }
                                else if (happinessRaiting == 1)
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "Hello stranger, It sure is nice seeing the kids again.");
                                }
                                else
                                {
                                    MessageManager.messageManager.QueueMessage(oldWomanName, "Hello stranger, I'm not feeling so great right now, please leave me alone.");
                                }

                                break;
                            }
                    }
                    break;
                }
            //Talking to the child in the sugar
            case sugarChildName:
                {
                    switch (shapeshifter.spriteName)
                    {
                        case maleChickenName:
                        case femaleChickenName:
                            {
                                MessageManager.messageManager.QueueMessage(sugarChildName, "Leave my Sugar alone Chicken!");
                                break;
                            }
                        case oldWomanName:
                            {
                                if (gotSugar)
                                {
                                    MessageManager.messageManager.QueueMessage(sugarChildName, "I want to be super sweet!");

                                }
                                else
                                {
                                    MessageManager.messageManager.QueueMessage(sugarChildName, "Oh you're Auntie, here have some of my sugar.");
                                    MessageManager.messageManager.QueueMessage("", "You got sugar.");
                                    gotSugar = true;
                                }

                                break;
                            }
                        case cakeName:
                            {
                                MessageManager.messageManager.QueueMessage(sugarChildName, "I am sweeter!");
                                break;
                            }
                        case steveName:
                        case sebastianName:
                        case saphireName:
                        case arnoldName:
                        default:
                            {
                                MessageManager.messageManager.QueueMessage(sugarChildName, "Go Away! This is my Sugar!");
                                break;
                            }
                    }
                    break;
                }
            //Interacting with a fridge
            case (fridgeName):
                {
                    MessageManager.messageManager.QueueMessage("", "It's a sheet of carboard made to look like a fridge.");
                    break;
                }
            //Interacting with the oven
            case (ovenName):
                {
                    //Either we've made the cake, we can make the cake, or we can't
                    if (madeCake)
                    {
                        MessageManager.messageManager.QueueMessage("", "If you leave it long enough someone else will clean it.");
                    }
                    else if (gotEgg && gotMilk && gotSugar)
                    {
                        MessageManager.messageManager.QueueMessage("", "You made a cake!");
                        cakeObject.SetActive(true);
                        madeCake = true;
                    }
                    else
                    {
                        MessageManager.messageManager.QueueMessage("", "You can use this oven to make a cake, you need milk, sugar and an egg.");
                    }
                    break;
                }
            //Interacting with the cake
            case cakeName:
                {
                    MessageManager.messageManager.QueueMessage("", "It's a cake, you should try shapeshifting as it.");
                    break;
                }
            //Steve finishing speaking when the player speaks to steve as the cake
            case steveCakeReaction:
                {
                    cameraGrabber.EndGame();
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
