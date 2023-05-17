using UnityEngine;
using System.Collections;

//this script is on the FishingRod
public class Fishing : MonoBehaviour
{
    [Header("int")]
    public int random; //int to store the value of Random.Range

    [Header("bools")]
    public bool CardCollected; //bool for when the fish card is collected
    public bool canfish; //bool for if the player can fish or not

    [Header("GameObjects")]
    public GameObject Player; //the players GameObject
    public GameObject CardFragment1; //the first card fragment, which the player gets randomly via fishing
    public GameObject Quest; //to get the questmanager script
    public GameObject FishIndicator;

    public GameObject FishingIndicatorUI;

    private IEnumerator coroutine1;

    public AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void FixedUpdate()
    {
        if(canfish)
        {
            if(Input.GetKey(KeyCode.F))
            {
                FishIndicator.SetActive(false);
                Fished();
                canfish = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        coroutine1 = FishTimer(Random.Range(2, 4));
        FishingIndicatorUI.SetActive(true);
        StartCoroutine(coroutine1);
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FishingIndicatorUI.SetActive(false);
        StopCoroutine(coroutine1);
        audio.Stop();
    }


    public void Fished()
    {
        random = Random.Range(0, 10); //set random to random value between 0 and 10

        //odds of getting a card increased for the demo gameplay
        if (random == 5 && CardCollected == false) //if the random value is 5, 4, 3, 1 or 10, and the card hasnt been collected
        {
            CardCollected = true; //set CardCollected to true
            CardFragment1.SetActive(true); //enable the card in the inventory
            Player.GetComponent<Player>().CardFragmentCollected(); //trigger the players CardFragmentCollected function
        }
        else //if random is not 5, 4, 3, 1 or 10, or the card has been collected
        {
            Quest.GetComponent<QuestManager>().CrayfishQuestUpdate(); //trigger the questmanagers CrayfishQuestUpdate function
        }
    }

    private IEnumerator FishTimer(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            StartCoroutine(coroutine1);
            FishIndicator.SetActive(true);
            canfish = true;
        }
    }
}
