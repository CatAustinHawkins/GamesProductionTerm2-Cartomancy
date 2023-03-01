using UnityEngine;
using TMPro;

//on the inventory manager
public class Inventory : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject CardInventoryUI; //the gameobject parent that displays the card inventory
    public GameObject ItemInventoryUI; //the gameobject parent that displays the item inventory
    public GameObject GameplayUI; //the gameobject parent tht displays the gameplayUI
    public GameObject Object1; //the first card's object to be inspected (Cube Card - Cube Object)
    public GameObject Object2; //the second card's object to be inspected (Fish Card - Fish Object)
    public GameObject CameraRotateRoom; //The item inspection room 
    public GameObject Player; //the player character
    public GameObject BacktoPlaying; //The BacktoPlaying button
    
    [Header("TextMeshProUGUI")]
    public TextMeshProUGUI Card; //the text that displays which card is currently 

    [Header("Card Page Info")]
    public GameObject[] CardPage; //Array for all the CardPages
    public int CardCurrentPage = 0; //CardCurrentPage used to track which page is currently open. Set to 0 initally as the card inventory opens up on page 0.
    public bool cardinventoryopen = false; //cardinventoryopen used to track whether the item inventory is open or not

    [Header("Item Page Info")]
    public GameObject[] ItemPage; //Array for all the ItemPages
    public int ItemCurrentPage = 0; //ItemCurrentPage used to track which page is currently open. Set to 0 initally as the item inventory opens up on page 0.
    public bool iteminventoryopen = false; //iteminventoryopen used to track whether the item inventory is open or not

    [Header("Timer Info")]
    public float timer;
    public bool timeractive;


    private void FixedUpdate()
    {
        //start the timer
        if (timeractive)
        {
            //add to the timer
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > 0.5f) //if more than 1 second has passed
        {
            timeractive = false; //stop the timer
            timer = 0f;
        }

        //timer set up so the player can open and close the inventory and card pages smoothly

        if (Input.GetKey(KeyCode.C)) //when the player presses C
        {
            if(cardinventoryopen && timeractive == false) //if the cardinventory is open, and the timer isnt running
            {
                CardInventoryUI.SetActive(false); //close the CardInventory
                cardinventoryopen = false; //set the cardinventoryopen bool to false
                timeractive = true; //start the timer
            }

            if(cardinventoryopen == false && timeractive == false) //if the cardinventory is closed, and the timer isnt running
            {
                ItemInventoryUI.SetActive(false); //close the ItemInventory, to prevent an accidental overlap
                iteminventoryopen = false; //set the iteminventoryopen bool to false
                CardInventoryUI.SetActive(true); //open the CardInventory
                cardinventoryopen = true; //set the cardinventory open bool to true
                timeractive = true; //start the timer
            }
        }

        if (Input.GetKey(KeyCode.I)) //when the player presses I
        {
            if (iteminventoryopen && timeractive == false)
            {
                ItemInventoryUI.SetActive(false);  //close the ItemInventory
                iteminventoryopen = false; //set the iteminventoryopen bool to false
                timeractive = true; //start the timer
            }

            if (iteminventoryopen == false && timeractive == false)
            {
                CardInventoryUI.SetActive(false); //close the CardInventory, to prevent an accidental overlap
                cardinventoryopen = false; //set the cardinventoryopen bool to false
                ItemInventoryUI.SetActive(true);  //open the ItemInventory
                iteminventoryopen = true; //set the iteminventoryopen bool to true
                timeractive = true; //start the timer
            }
        }
    }


    public void Card1Clicked() //when the Card1 button is Clicked 
    {
        Object1.SetActive(true); //enables the object1 for the player to inspect and interact with
        CameraRotateRoom.SetActive(true); //enables the item inspection room
        Player.SetActive(false); //disable the player - also disabling the main camera
        BacktoPlaying.SetActive(true); //enable the Back To Game button, so the player can leave the item inspection
        GameplayUI.SetActive(false); //disable the gameplay UI
        Card.text = "The Cube Card"; //tell the player they are inspecting the cube card
    }

    public void Card2Clicked() //when the Card2 button is Clicked 
    {
        Object2.SetActive(true); //enables the object2 for the player to inspect and interact with
        CameraRotateRoom.SetActive(true); //enables the item inspection room
        Player.SetActive(false); //disable the player - also disabling the main camera
        BacktoPlaying.SetActive(true); //enable the Back To Game button, so the player can leave the item inspection
        GameplayUI.SetActive(false); //disable the gameplay UI
        Card.text = "The Fish Card"; //tell the player they are inspecting the fish card

    }

    public void BacktoGame() //triggered by the Back to Game Button
    {
        Player.SetActive(true); //enable the player, and enables the main camera
        CameraRotateRoom.SetActive(false); //disables the item inspection room
        Object1.SetActive(false); //hides the object1 that the player was inspecting
        GameplayUI.SetActive(true); //enables the gameplayUI
        Object2.SetActive(false); //hides the object2 that the player was inspecting
        BacktoPlaying.SetActive(false); //disables the 'Back To Game' button, as it is no longer needed
    }

    public void CardNextPage() //Display the next card page - triggered by the > button on card pages 
    {
        CardPage[CardCurrentPage].SetActive(false); //disable the current page
        CardCurrentPage++; //increment the CardCurrentPage int
        CardPage[CardCurrentPage].SetActive(true); //enable the current page 
    }

    public void CardPreviousPage() //Display the next card page - triggered by the < button on card pages 
    {
        CardPage[CardCurrentPage].SetActive(false); //disable the current page
        CardCurrentPage--; //decrement the CardCurrentPage int
        CardPage[CardCurrentPage].SetActive(true); //enable the current page 
    }

    public void ItemNextPage() //Display the next item page - triggered by the > button on item pages 
    {
        ItemPage[ItemCurrentPage].SetActive(false); //disable the current page
        ItemCurrentPage++; //increment the ItemCurrentPage int
        ItemPage[ItemCurrentPage].SetActive(true); //enable the current page 
    }

    public void ItemPreviousPage() //Display the next item page - triggered by the < button on item pages 
    {
        ItemPage[ItemCurrentPage].SetActive(false); //disable the current page
        ItemCurrentPage--; //decrement the ItemCurrentPage int
        ItemPage[ItemCurrentPage].SetActive(true); //enable the current page 
    }
}
