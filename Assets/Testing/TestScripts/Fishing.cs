using UnityEngine;

public class Fishing : MonoBehaviour
{
    [Header("int")]
    public int random;

    [Header("int")]
    public float timer;

    [Header("bools")]
    public bool timergo = false;
    public bool CardCollected;
    public bool canfish;

    [Header("GameObjects")]
    public GameObject CardText;
    public GameObject[] FishingSpot;
    public GameObject FishingSpotToBeSpawned;
    public GameObject Player;
    public GameObject Card2NotCollected;
    public GameObject Card2;

    public void FixedUpdate()
    {
        if (timergo)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > Random.Range(6, 10))
        {
            FishingSpotToBeSpawned = FishingSpot[Random.Range(0, 5)];
            FishingSpotToBeSpawned.SetActive(true);
            CardText.SetActive(false);
            timer = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        timergo = true;
    }
    public void OnTriggerExit(Collider other)
    {
        timergo = false;
        timer = 0;
    }
    public void Fished()
    {
        random = Random.Range(0, 10);

        if (random == 5 || random == 10 && CardCollected == false)
        {
            CardText.SetActive(true);
            CardCollected = true;
            Card2.SetActive(true);
            Card2NotCollected.SetActive(false);
        }
        else
        {
            Player.GetComponent<Player>().OnCoinCollection();
        }
    }
}
