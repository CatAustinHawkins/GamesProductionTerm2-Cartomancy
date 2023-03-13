using UnityEngine;
using TMPro;

//On the QuestManager object
public class QuestManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject QuestBox; //the QuestBox that shows the player what quests they have
    public GameObject Quest1; //the first - and currently only - quest in the quest list

    [Header("Booleans")]
    public bool questopen = false; //if the QuestBox is active, set questopen to true, if QuestBox is inactive, set questopen to false

    [Header("Timers")]
    public bool timeractive; //when true, the timer begins
    public float timer; //float 

    [Header("TextMeshProUGUI")]
    public TextMeshProUGUI Quest1Text;
    public TextMeshProUGUI Quest2Text;
    public TextMeshProUGUI Quest3Text;

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
            timer = 0f; //reset the timer
        }

        //timer set up so the player can open and close the quest box smoothly

        if (Input.GetKey(KeyCode.Q)) //when the player presses Q
        {
            if (questopen && timeractive == false) //if the quest box is open and the timer is false
            {
                QuestBox.SetActive(false); //disable the quest box
                questopen = false; //set questopen to false
                timeractive = true; //start the timer
            }

            if (questopen == false && timeractive == false) //if the quest box is closed and the timer is false
            {
                QuestBox.SetActive(true); //enable the quest box
                questopen = true; //set questopen to true
                timeractive = true; //start the timer
            }
        }
    }

    public void Quest1Complete() //called by the Coin script 
    {
        Quest1.SetActive(false); //disable the Quest1 GameObject, so the player knows they completed a quest
    }

    public void CapeQuestUpdate()
    {

    }

    public void CrownQuestUpdate()
    {

    }

}
