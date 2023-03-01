using UnityEngine;

//on each NPC character
public class NPC : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Dialogue; //get the Dialogue GameObject, to get the dialogue scripts function
    public GameObject DialogueBox; //get the DialogueBox, which shows the player the dialogue. 

    [Header("Dialogue Script")]
    public Dialogue DialogueScript; //get the dialogue script to access its variables easily

    [Header("Timers")]
    public bool timeractive; //when true, the timer begins
    public float timer; //float 

    [Header("Booleans")]
    public bool dialogueopen = false; //dialogueopen bool, set to true when the DialogueBox is active and false when it is inactive
    public bool PlayerInTrigger; //when the player is in the NPCs trigger, set to true

    public int NPCNumber;
    public string NPCName;

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

        //timer set up so the player can open and close the dialogue box smoothly

        if (PlayerInTrigger) //if the player is in the NPCs trigger
        {
            if (Input.GetKey(KeyCode.E) && dialogueopen == false && timeractive == false) //if the player is pressing E, the DialogueBox is closed and the timer is not running
            {
                DialogueScript.NPCCounter = NPCNumber; //set the NPCCounter to 1 - as this is the first NPC
                DialogueScript.NPCName.text = NPCName;
                Dialogue.GetComponent<Dialogue>().DialogueTrigger(); //call to the DialogueTrigger function on the dialogue script
                dialogueopen = true; //set dialogueopen to true
                timeractive = true; //set timeractive to true
                DialogueBox.SetActive(true); //open the dialogue box
            }

            if (Input.GetKey(KeyCode.E) && dialogueopen && timeractive == false) //if the player is pressing E, the DialogueBox is open and the timer is not running
            {
                DialogueBox.SetActive(false); //close the dialoguebox
                dialogueopen = false; //change the dialogueopen to false
                timeractive = true; //start running the timer
            }
        }
    }

    public void OnTriggerEnter(Collider other) //when an object enters the NPCs trigger
    {
        PlayerInTrigger = true; //set PlayerInTrigger to true
    }

    public void OnTriggerExit(Collider other) //when an object exits the NPCs trigger
    {
        PlayerInTrigger = false; //set PlayerInTrigger to false
        DialogueBox.SetActive(false); //close the dialogue box
        dialogueopen = false; //set dialogueopen to false
    }
}
