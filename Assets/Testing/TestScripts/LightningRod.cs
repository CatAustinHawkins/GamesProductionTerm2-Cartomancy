using UnityEngine;

//script on the lightning rod the player has to collect and take up the mountain

public class LightningRod : MonoBehaviour
{
    public GameObject Player; //get the player, to get its transform values

    public bool FollowPlayer; //bool to track whether the rod is following the player

    public GameObject CardFragment3; //the third card fragment in the card inventory

    public Collider RodCollider; //get the collider of the lightning rod

    public void FixedUpdate()
    {
        if(FollowPlayer) //if the lightning rod is following the player
        {
            gameObject.transform.position = Player.transform.position; //set the gameobjects transform postion to the same as the player
            gameObject.transform.position += new Vector3(0.3f,-0.3f,0); //distance the rod from the player
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("CollisionLR"); //check if something has collided with the lightning rod, and if yes then message the debug log
        if(other.tag == "Player") //if the player collides with the rod
        {
            FollowPlayer = true; //set followplayer to true, so the rod starts to follow
        }
        
        if(other.tag == "TopOfMountain") //if the rod collides with the top of the mountain
        {
            Debug.Log("Mountain");
            FollowPlayer = false; //set followplayer to false, as the rod will no longer be following the player
            CardFragment3.SetActive(true); //enable the third card fragment in the inventory
            RodCollider.enabled = false; //disable the rodcollider

        }
    }

}
