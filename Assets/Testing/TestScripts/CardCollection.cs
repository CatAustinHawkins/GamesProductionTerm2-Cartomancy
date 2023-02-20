using UnityEngine;

//script on collectable cards
public class CardCollection : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Card; //the card in the inventory
    public GameObject CardNotCollected; //the ? card in the inventory
    public GameObject CardText; //text to tell the player that they have collected a card

    [Header("Timers")]
    public bool timeractive; //when true, the timer begins
    public float timer; //float 



    public void FixedUpdate()
    {
        //start the timer
        if(timeractive)
        {
            //add to the timer
            timer = timer + 1 * Time.deltaTime;
        }

        //after 5 seconds
        if (timer > 5f)
        {
            //hide the card text - the player has had enough time to read the text
            CardText.SetActive(false);
        }
    }

    
    //When the player approaches a card
    private void OnTriggerEnter(Collider other)
    {
        Card.SetActive(true); //enable the card in the inventory so the player can see it and interact with it 
        CardNotCollected.SetActive(false); //disables the ? card in the inventory - as the player has collected the card
        
        Destroy(gameObject); //destory the card game object

        CardText.SetActive(true); //enable the text to tell the player they recieved a card
        timeractive = true; //enable the timer
    }
}
