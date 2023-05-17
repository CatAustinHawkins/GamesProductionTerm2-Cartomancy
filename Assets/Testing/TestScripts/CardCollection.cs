using UnityEngine;
using System.Collections;

//script on collectable cards
public class CardCollection : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Card; //the card in the inventory
    public GameObject CardNotCollected; //the ? card in the inventory - to show the player that they don't have the card yet
    public GameObject CardText; //text to tell the player that they have collected a card

    private IEnumerator coroutine1; //timer - triggered when the player collects a card
    
    //When the player approaches a card
    private void OnTriggerEnter(Collider other)
    {
        Card.SetActive(true); //enable the card in the inventory so the player can see it and interact with it 
        CardNotCollected.SetActive(false); //disables the ? card in the inventory - as the player has collected the card
        
        Destroy(gameObject); //destory the card game object

        CardText.SetActive(true); //enable the text to tell the player they recieved a card
        coroutine1 = CardTextTimer(5); //set up the coroutine, with a timer of 5 seconds
        StartCoroutine(coroutine1); //start coroutine
    }


    private IEnumerator CardTextTimer(float waitTime)
    {
        while (true) //while the coroutine is running
        {
            yield return new WaitForSecondsRealtime(waitTime); //wait 5 seconds
            CardText.SetActive(false); //disable the card text
        }
    }
}
