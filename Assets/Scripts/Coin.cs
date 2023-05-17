using UnityEngine;

//script on each coin
public class Coin : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Player; //the Players character
    public GameObject WholeCoin; //the whole coin object


    public AudioSource audio;


    //when the player overlaps with the item
    public void OnTriggerEnter(Collider other)
    {
        //Debug Log Comment
        Debug.Log("Coin Collided With");

        //if the overlapped object is tagged with Player
        if(other.tag == "Player")
        {
            //Call to the Player to say that they have collected a coin
            Player.GetComponent<Player>().OnCoinCollection();
            audio.Play();

            //Destory the whole coin
            Destroy(WholeCoin);
        }
    }
}
