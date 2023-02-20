using UnityEngine;

public class CardCollection : MonoBehaviour
{
    public GameObject Card;
    public GameObject CardNotCollected;
    public GameObject CardText;

    public bool timeractive;
    public float timer;

    public void Update()
    {
        if(timeractive)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        if (timer > 5f)
        {
            CardText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Card.SetActive(true);
        CardNotCollected.SetActive(false);
        Destroy(gameObject);
        CardText.SetActive(true);
        timeractive = true;
    }
}
