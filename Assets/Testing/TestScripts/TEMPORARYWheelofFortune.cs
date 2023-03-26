using UnityEngine;

//temporary script for the wheel of fortune mechanic

public class TEMPORARYWheelofFortune : MonoBehaviour
{
    public GameObject wheeloffortunetext; //the text that displays to tell the player what the wheel of fortune is 

    [Header("Timers")]
    public bool timeractive; //when true, the timer begins
    public float timer; //float 

    public GameObject player; //get the player, to access its functions
    public GameObject cardfragment5; //the fifth cardfragment image in the card inventory

    public void Update()
    {
        //start the timer
        if (timeractive)
        {
            //add to the timer
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > 3) //if more than 1 second has passed
        {
            timeractive = false; //stop the timer
            timer = 0f; //reset the timer
            wheeloffortunetext.SetActive(false); //set the wheel of fortune text to false
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(timeractive == false) //if the timer isn't running
        {
            player.GetComponent<Player>().CardFragmentCollected(); //call to the player and the CardFragmentCollected function
            cardfragment5.SetActive(true); //enable the fifth card fragment image in the inventory
            wheeloffortunetext.SetActive(true); //set the wheel of fortune text to true
            timeractive = true; //start the timer
        }

    }

}
