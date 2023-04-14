using UnityEngine;
using TMPro;

//On the QuestManager object
public class QuestManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject OpenQuestBox; //the QuestBox that shows the player what quests they have
    public GameObject ClosedQuestBox; 

    [Header("Booleans")]
    public bool questopen = false; //if the QuestBox is active, set questopen to true, if QuestBox is inactive, set questopen to false

    [Header("Timers")]
    public bool timeractive; //when true, the timer begins
    public float timer; //float 

    [Header("TextMeshProUGUI")]
    public TextMeshProUGUI CrayfishQuestText; //the text for quest one - the crayfish collection quest
    public TextMeshProUGUI CapeQuestText; //the text for quest two - the cape collection quest
    public TextMeshProUGUI CrownQuestText; //the text for quest three - the crown collection quest

    public int CrayfishCount; //crayfishcount integer, to track how many crayfish the player has caught

    [Header("Quest Bools")]
    public bool CapeCollected; //if the player has collected the cape
    public bool CrownCollected; //if the player has collected the crown 
    public bool TenFishCollected; //if the player has collected 10 crayfish

    public bool FishingQuestInProgress; //if the crayfish quest is in progress
    public bool CapeQuestInProgress; //if the cape quest is in progress
    public bool CrownQuestInProgress; //if the crown quest is in progress

    public bool FishingQuestBegan; //if the fishing quest is in progress
    public bool CapeQuestBegan; //if the cape quest is in progress
    public bool CrownQuestBegan; //if the crown quest is in progress

    public GameObject Crown; //the crown gameobject

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
                OpenQuestBox.SetActive(false); //disable the quest box
                ClosedQuestBox.SetActive(true);
                questopen = false; //set questopen to false
                timeractive = true; //start the timer
            }

            if (questopen == false && timeractive == false) //if the quest box is closed and the timer is false
            {
                OpenQuestBox.SetActive(true); //enable the quest box
                ClosedQuestBox.SetActive(false);
                questopen = true; //set questopen to true
                timeractive = true; //start the timer
            }
        }
    }

    //some of these functions are currently unused.
    public void CapeQuestBegin()
    {
        CapeQuestText.text = "Quest 2 - Collect Red Cape";
        CapeQuestBegan = true;
    }

    public void CrownQuestBegin()
    {
        CrownQuestText.text = "Quest 3 - Collect Crown";
        CrownQuestBegan = true;
    }

    public void FishingQuestBegin()
    {
        CrayfishQuestText.text = "Quest 1 - Collect 10 Crayfish 0/10";
        FishingQuestBegan = true;
    }

    public void CapeQuestUpdate()
    {
        CapeCollected = true;
        CapeQuestText.text = "Quest 2 - Complete! Go to NPC 1";
    }

    public void CrownQuestUpdate()
    {
        CrownCollected = true;
        CrownQuestText.text = "Quest 3 - Complete! Go to NPC 2";
    }

    public void CrayfishQuestUpdate()
    {
        CrayfishCount++;
        
        if(CrayfishCount == 2)
        {
            CrayfishQuestText.text = "Quest 1 - Complete! Go to the Fisherman.";
            TenFishCollected = true;
        }
        else
        {
            CrayfishQuestText.text = "Quest 1 - Collect 2 Crayfish " + CrayfishCount + "/2";
        }        
    }
     
    public void CrayfishQuestComplete()
    {
        CrayfishQuestText.text = "Quest 1 - Complete";

        Crown.SetActive(true); //so the player can collect it

    }

    public void CapeQuestComplete()
    {
        CapeQuestText.text = "Quest 2 - Complete";
    }

    public void CrownQuestComplete()
    {
        CrownQuestText.text = "Quest 3 - Complete";
    }

}
