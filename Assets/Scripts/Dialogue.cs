using UnityEngine;
using TMPro; //so I can access TextMeshProUGUI objects
using System.Collections;

public class Dialogue : MonoBehaviour
{
    [Header("Strings")]
    public string CurrentText; //This string will be set to the value of NewText, and will be used in the DisplayText Coroutine
    public string NewText; //The string that the NPCs will update to change the current dialogue

    [Header("GameObjects")]
    public GameObject DialogueBox; //The UI element that holds all the dialogue text and button items
    public GameObject Option1Button; //The Option1 button, made visible and invisible based on whether the player requires the option

    [Header("Text Mesh Pro Objects")]
    public TextMeshProUGUI NPCName; //The text element that displays the NPCs name
    public TextMeshProUGUI DialogueText; //The text element that displays what the NPC is saying

    [Header("ints")]
    public int NPCCounter; //The number coorelates to the NPC the player is currently talking to

    //int = 1 - First NPC - Capeless - In the NPC Hub
    //int = 2 - Second NPC - Crownless - In the NPC Hub
    //int = 3 - Third NPC - Crayfish

    //int = 4 - Intro NPC Tutorial
    //int = 5 - Forest NPC
    //int 6 = Wheel of Fortune NPC
    //int 7 = Fog Maze Player Dialogue
    //int 8 = Tower Player Dialogue 
    //int 9 = NPC Hub Dialogue 

    public int DialogueCounter;

    [Header("The Quest Manager")]
    public QuestManager QuestScript; //To access the variables in the questmanager script 
    public GameObject QuestManager; //To access the functions in the questmanager script

    [Header("Card Items")]
    public GameObject Card7; //the seventh card fragment image in the card inventory
    public GameObject Card8; //the eighth card fragment image in the card inventory

    [Header("Player")]
    public GameObject Player; //the player, to access their functions

    public GameObject Crown;


    //bools to control dialogue
    public bool RodPurchased;


    public void DialogueTrigger() //triggered by an NPC when a player collides with them and presses E.
    {
        switch(NPCCounter)
        {
            case 1:
                NPC1DialogueTrigger(); 
                break;

            case 2:
                NPC2DialogueTrigger();
                break;

            case 3:
                CrayfishNPCTrigger();
                break;

            case 4:
                TutorialNPCTrigger();
                break;

            case 5:
                ForestNPCTrigger();
                break;

            case 6:
                WheelofFortuneNPCTrigger();
                break;

            case 7:
                FogMazePlayerDialogueTrigger();
                break;
            case 8:
                TowerPlayerDialogueTrigger();
                break;
        }
        


        CurrentText = NewText; //The NPC changes the text to be displayed in their script - through NewText. 
        StartCoroutine(DisplayText()); //start the coroutine to display text
    }

    //NPC 1 - Missing Cape NPC 
    public void NPC1DialogueTrigger()
    {
        NPCName.text = "Capeless - NPC 1"; //set the npc name text object to display the name of the NPC

        if (QuestScript.CapeQuestBegan == false) //check if the CapeQuestBegan boolean on the QuestScript is true or false - i.e., if the player had recieved the quest or not yet
        {
            NewText = "Can you collect my cape please?"; //if false, ask the player if they can collect the cape
            //would then show the quest on the quest menu
        }

        if(QuestScript.CapeCollected) //if the player has collected the NPC's cape
        {
            NewText = "Thank you for collecting my cape!"; //change the text accordingly
            Card7.SetActive(true); //enable the card fragment to be visible in the card inventory
            Player.GetComponent<Player>().CardFragmentCollected(); //call the CardFragmentCollected function on the player
            QuestScript.CapeCollected = false; //change the CapeCollected variable to false - this is a temporary measure, to stop the NPC from repeating the dialogue again
            QuestManager.GetComponent<QuestManager>().CapeQuestComplete(); //call to the QuestManager, and trigger the CapeQuestComplete function
        }
    }

    //NPC 2 - Missing Crown NPC
    public void NPC2DialogueTrigger()
    {
        NPCName.text = "Crownless - NPC 2"; //set the npc name text object to display the name of the NPC

        if (QuestScript.CrownQuestBegan == false)//check if the CrownQuestBegan boolean on the QuestScript is true or false - i.e., if the player had recieved the quest or not yet
        {
            NewText = "Can you collect my crown please?";//if false, ask the player if they can collect the crown
        }

        if (QuestScript.CrownCollected) //check if the crowncollected bool on the questmanager script is set to true, meaning the player has collected the crown
        {
            NewText = "Thank you for collecting my crown!"; //thank the player
            Card8.SetActive(true); //enable the card fragment image on the card inventory 
            Player.GetComponent<Player>().CardFragmentCollected(); //call the CardFragmentCollected function on the player
            QuestScript.CrownCollected = false; //change the CrownCollected variable to false - this is a temporary measure, to stop the NPC from repeating the dialogue again
            QuestManager.GetComponent<QuestManager>().CrownQuestComplete(); //call to the QuestManager, and trigger the CrownQuestComplete function

        }
    }

    //NPC 3 - Crayfish NPC
    public void CrayfishNPCTrigger()
    {
        NPCName.text = "Crayfish NPC"; //set the npc name text object to display the name of the NPC

        if (QuestScript.FishingQuestBegan)//check if the FishingQuestBegan boolean on the QuestScript is true or false - i.e., if the player had recieved the quest or not yet
        {
            NewText = "Can you please collect 10 crayfish?"; //ask the player to collect 10 crayfish
        }

        if(QuestScript.FishingQuestInProgress)//if the quest is in progress
        {
            NewText = "nice work"; 
        }

        if(QuestScript.TenFishCollected) //if ten fish are collected i.e, if the quest is completed
        {
            NewText = "Thank you. You may have my crown, as a reward."; //thank the player for collecting the fish
            Crown.SetActive(true); //enable the crown, for the player to collect for the quest
            QuestManager.GetComponent<QuestManager>().CrayfishQuestComplete(); //call to the questmanager, triggering the crayfishquestcomplete function
        }

    }

    //Intro NPC Tutorial
    public void TutorialNPCTrigger()
    {
        NPCName.text = "Player"; //set the npc name text object to display the name of the NPC
        NewText = "Where... am I? What is this place?";

    }

    //Forest NPC
    public void ForestNPCTrigger()
    {
        NPCName.text = "Forest NPC - Name Undecided"; //set the npc name text object to display the name of the NPC

    }

    //Wheel of Fortune NPC
    public void WheelofFortuneNPCTrigger()
    {

    }

    //Fog Maze Player Dialogue
    public void FogMazePlayerDialogueTrigger()
    {
        NPCName.text = "Player";
    }

    //Tower Player Dialogue
    public void TowerPlayerDialogueTrigger()
    {
        NPCName.text = "Player";
    }

    private IEnumerator DisplayText() //triggered in DialogueTrigger
    {
        DialogueText.text = ""; //sets the dialogue text to nothing - so the scrolling text dialogue can begin

        foreach(char c in CurrentText.ToCharArray()) //for each character in the current text string
        {
            DialogueText.text += c; //add the character to the dialogue text
            yield return new WaitForSecondsRealtime(0.05f); //wait 0.05 seconds - then repeat
        }
    }

    //When the player presses the first option button - the Next button
    public void Option1()
    {
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 1 was clicked."; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                break; //end case 1

            case 2:
                NewText = "Thank you. Quest Recieved"; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                break; //end case 1

            case 3:
                NewText = "Thank you. Quest Recieved"; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                break; //end case 1

            case 4:
                NewText = "Go to the fishing pool."; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                break; //end case 1
        }
    }

    public void BuyFishingRod()
    {
        RodPurchased = true;
    }


}
