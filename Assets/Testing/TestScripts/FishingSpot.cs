using UnityEngine;

//On each fishing spot
public class FishingSpot : MonoBehaviour
{
    [Header("Booleans")]
    public bool PlayerOverlapping; //if Player is in the FishingSpots trigger

    [Header("Float")]
    public float timer; //float value for the timer

    [Header("GameObjects")]
    public GameObject FishingPool; //The fishing pool, which has the Fishing Script

    public void FixedUpdate()
    {
        timer = timer + 1 * Time.deltaTime; //run the timer

        if(timer > 5) //if timer is more than 5
        {
            gameObject.SetActive(false); //make the fishing spot disappear
        }

        if(PlayerOverlapping) //if the player overlaps with the fishing spot
        {
            if(Input.GetKey(KeyCode.F)) //if player presses F
            {
                FishingPool.GetComponent<Fishing>().Fished(); //call to the fishing script that the player has fished
                gameObject.SetActive(false); //disable the fishing spot
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerOverlapping = true; //if anything enters the trigger, enable PlayerOverlapping
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerOverlapping = false; //if anything exits the trigger, enable PlayerOverlapping
    }
}
