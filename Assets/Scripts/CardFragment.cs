using UnityEngine;

//used on every card fragment 

public class CardFragment : MonoBehaviour
{
    public int CardFragmentNumber; //to store which card fragment it is

    public GameObject CardFragmentImage; //the image of the card in the inventory

    public GameObject Player; //the player, to acess its functions

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //check if the gameobject that collided with the card fragment is the player
        {
            CardFragmentImage.SetActive(true); //enable the card fragment image in the card inventory
            Player.GetComponent<Player>().CardFragmentCollected(); //call to the players card fragment collected function
            Destroy(gameObject); //remove the card fragment gameobject from the scene
        }
    }
}
