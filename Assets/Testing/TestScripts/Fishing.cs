using UnityEngine;

//this script is on the FishingPool
public class Fishing : MonoBehaviour
{
    [Header("int")]
    public int random; //int to store the value of Random.Range

    [Header("int")]
    public float timer; //float for the timer

    [Header("bools")]
    public bool timeractive = false; //bool for the timer - when true timer begins
    public bool CardCollected; //bool for when the fish card is collected
    public bool canfish; //bool for if the player can fish or not

    [Header("GameObjects")]
    public GameObject CardText; //GameObject to display that the card has been collected
    public GameObject[] FishingSpot; //The array of fishing spots in the scene
    public GameObject FishingSpotToBeSpawned; //which spot to enable
    public GameObject Player; //the players GameObject
    public GameObject Card2NotCollected; //
    public GameObject Card2;

    public void FixedUpdate()
    {
        //start the timer
        if (timeractive)
        {
            //add to the timer
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > Random.Range(6, 10)) //if timer higher than the random value between 6 and 10
        {
            FishingSpotToBeSpawned = FishingSpot[Random.Range(0, 5)]; //spawn a random fishing spot
            FishingSpotToBeSpawned.SetActive(true); //set the spot active
            CardText.SetActive(false); //disable the cardtext
            timer = 0; //reset the timer
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        timeractive = true; //enable the timer 
    }
    public void OnTriggerExit(Collider other)
    {
        timeractive = false; //disable the timer
        timer = 0; //set the timer to 0
    }


    public void Fished()
    {
        random = Random.Range(0, 10); //set random to random value between 0 and 10

        if (random == 5 || random == 10 && CardCollected == false) //if the random value is 5 or 10, and the card hasnt been collected
        {
            CardText.SetActive(true); //enable the text to tell the player they got a card
            CardCollected = true; //set CardCollected to true
            Card2.SetActive(true); //enable the card in the inventory
            Card2NotCollected.SetActive(false); //disables the ? card in the inventory
        }
        else //if random is not 5 or 10, or the card has been collected
        {
            Player.GetComponent<Player>().OnCoinCollection(); //call to the player to increase their coin count
        }
    }
}
