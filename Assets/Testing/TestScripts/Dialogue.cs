using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    [Header("Strings")]
    public string CurrentText; //
    public string NewText; //N

    [Header("GameObjects")]
    public GameObject DialogueBox; //
    public GameObject Option1Button; //
    public GameObject Option2Button; //
    public GameObject Option3Button; //

    [Header("Text Mesh Pro Objects")]
    public TextMeshProUGUI NPCName; //
    public TextMeshProUGUI DialogueText; //
    public TextMeshProUGUI Option1Text; //
    public TextMeshProUGUI Option2Text; //
    public TextMeshProUGUI Option3Text; //

    [Header("ints")]
    public int NPCCounter; //The number coorelates to the NPC the player is currently talking to
    //int = 1 - the yellow NPC the player can talk to 


    public void DialogueTrigger() //triggered by an NPC when a player collides with them and presses E.
    {
        CurrentText = NewText; //The NPC changes the text to be displayed in their script - through NewText. 
        StartCoroutine(DisplayText()); //start the coroutine to display text

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
        }
    }

    private IEnumerator DisplayText() //triggered in DialogueTrigger
    {
        DialogueText.text = "";

        foreach(char c in CurrentText.ToCharArray())
        {
            DialogueText.text += c;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    //When the player presses the first option button
    public void Option1()
    {
        //Based on what NPC the player is currently talking to  
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 1 was clicked.";
                CurrentText = NewText;
                StartCoroutine(DisplayText());
                Option1Button.SetActive(false);
                Option2Button.SetActive(false);
                Option3Button.SetActive(false);
                break;
        }
    }

    //When the player presses the second option button
    public void Option2()
    {
        //Based on what NPC the player is currently talking to  
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 2 was clicked.";
                CurrentText = NewText;
                StartCoroutine(DisplayText());
                Option1Button.SetActive(false);
                Option2Button.SetActive(false);
                Option3Button.SetActive(false);
                break;
        }
    }

    //When the player presses the third option button
    public void Option3()
    {
        //Based on what NPC the player is currently talking to  
        switch (NPCCounter)
        {
            case 1:
                NewText = "Option 3 was clicked.";
                CurrentText = NewText;
                StartCoroutine(DisplayText());
                Option1Button.SetActive(false);
                Option2Button.SetActive(false);
                Option3Button.SetActive(false);
                break;
        }
    }
}
