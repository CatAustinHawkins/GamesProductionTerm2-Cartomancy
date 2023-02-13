using UnityEngine;

public class Fishing : MonoBehaviour
{
    public int random;
    public float timer;
    public bool timergo;
    public bool canfish;

    public GameObject FishText;
    public GameObject CardText;

    public void Update()
    {
        if (timergo)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > 1f)
        {
            timergo = false;
            timer = 0;
            CardText.SetActive(false);
            FishText.SetActive(false);
        }

        if (Input.GetKey(KeyCode.F) && canfish == true && timergo == false)
        {
            timergo = true;
            random = Random.Range(0, 10);

            if(random == 5)
            {
                CardText.SetActive(true);
            }
            else
            {
                FishText.SetActive(true);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "FishingPool")
        {
            canfish = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        canfish = false;
    }
}
