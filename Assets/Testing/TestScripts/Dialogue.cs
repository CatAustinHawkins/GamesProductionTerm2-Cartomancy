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
    public GameObject Option2Button; //The Option2 button, made visible and invisible based on whether the player requires the option
    public GameObject Option3Button; //The Option3 button, made visible and invisible based on whether the player requires the option

    [Header("Text Mesh Pro Objects")]
    public TextMeshProUGUI NPCName; //The text element that displays the NPCs name
    public TextMeshProUGUI DialogueText; //The text element that displays what the NPC is saying
    public TextMeshProUGUI Option1Text; //the text element that displays what Option1 is
    public TextMeshProUGUI Option2Text; //the text element that displays what Option2 is
    public TextMeshProUGUI Option3Text; //the text element that displays what Option3 is

    [Header("ints")]
    public int NPCCounter; //The number coorelates to the NPC the player is currently talking to
    //int = 1 - NPC Prototype Dialogue
    //int = 2 - First NPC - Capeless
    //int = 3 - Second NPC - Crownless
    //int = 4 - Third NPC - Crayfish

    public void DialogueTrigger() //triggered by an NPC when a player collides with them and presses E.
    {
        switch (NPCCounter) //based on what NPC the player is currently talking too
        {
            case 1: //the yellow NPC
                //enable all the option buttons
                Option1Button.SetActive(true);
                Option2Button.SetActive(true);
                Option3Button.SetActive(true);
                //change the text of each of the buttons
                Option1Text.text = "Ok";
                Option2Text.text = "...";
                Option3Text.text = "I see";
                break; //end case 1

            case 2:
                NewText = "I've lost my cape :( Can you find it?";

                Option1Text.text = "Ok";
                Option1Button.SetActive(true);

                Option2Text.text = "Nah";
                Option2Button.SetActive(true);
                break;

            case 3:
                NewText = "I've lost my crown >:( Can you find it?";

                Option1Text.text = "Ok";
                Option1Button.SetActive(true);

                Option2Text.text = "Nah";
                Option2Button.SetActive(true);
                break;

            case 4:
                NewText = "I.... am a crayfish. Please collect my brethren...";

                Option1Text.text = "Where?";
                Option1Button.SetActive(true);

                Option2Text.text = "Why";
                Option2Button.SetActive(true);
                break;
        }

        CurrentText = NewText; //The NPC changes the text to be displayed in their script - through NewText. 
        StartCoroutine(DisplayText()); //start the coroutine to display text
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

    //When the player presses the first option button
    public void Option1()
    {
        //Based on what NPC the player is currently talking to  
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 1 was clicked."; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                Option2Button.SetActive(false); //hide the option2 button
                Option3Button.SetActive(false); //hide the option3 button
                break; //end case 1

            case 2:
                NewText = "Thank you. Quest Recieved"; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                Option2Button.SetActive(false); //hide the option2 button
                break; //end case 1

            case 3:
                NewText = "Thank you. Quest Recieved"; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                Option2Button.SetActive(false); //hide the option2 button
                break; //end case 1

            case 4:
                NewText = "Go to the fishing pool."; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                Option2Button.SetActive(false); //hide the option2 button
                break; //end case 1
        }
    }

    //When the player presses the second option button
    public void Option2()
    {
        //Based on what NPC the player is currently talking to  
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 2 was clicked."; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                Option2Button.SetActive(false); //hide the option2 button
                Option3Button.SetActive(false); //hide the option3 button
                break; //end case 1
        }
    }

    //When the player presses the third option button
    public void Option3()
    {
        //Based on what NPC the player is currently talking to  
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 3 was clicked."; //change the value of NewText
                CurrentText = NewText; //set the value of CurrentText to NewText
                StartCoroutine(DisplayText()); //start the display text coroutine
                Option1Button.SetActive(false); //hide the option1 button
                Option2Button.SetActive(false); //hide the option2 button
                Option3Button.SetActive(false); //hide the option3 button
                break; //end case 1
        }
    }
}
