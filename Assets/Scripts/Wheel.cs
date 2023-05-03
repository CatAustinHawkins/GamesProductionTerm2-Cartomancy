using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wheel : MonoBehaviour
{
    private int randomvalue;
    private float timeInterval;
    private bool coroutineAllowed = true;
    private int finalAngle;

    public Player PlayerScript;
    public GameObject Player;
    public GameObject WheelOfFortuneUI;

    public TextMeshProUGUI RewardText;

    public GameObject CardFragment5;

    public void BeginSpin()
    {
        if(PlayerScript.Coin >= 1 && coroutineAllowed)
        {
            RewardText.text = "";
            PlayerScript.Coin--;
            StartCoroutine(Spin());
        }
    }
    
    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomvalue = Random.Range(20, 30);
        timeInterval = 0.1f;

        for (int i = 0; i < randomvalue; i++)
        {

            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomvalue * 0.5f))
            {
                timeInterval = 0.2f;
            }

            if (i > Mathf.RoundToInt(randomvalue * 0.85f))
            {
                timeInterval = 0.4f;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.5f);
        }

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch(finalAngle)
        {
            case 0:
                Debug.Log("1 - Nothing");
                RewardText.text = "You got Nothing! :(";
                break;

            case 45:
                Debug.Log("2 - Nothing");
                RewardText.text = "You got Nothing! :(";
                break;

            case 90:
                Debug.Log("3 - Nothing");
                RewardText.text = "You got Nothing! :(";
                break;

            case 135:
                Debug.Log("4 - Nothing");
                RewardText.text = "You got Nothing! :(";
                break;

            case 180:
                Debug.Log("5 - 1 Gold");
                RewardText.text = "You got 1 Gold!";
                PlayerScript.Coin++;
                break;

            case 225:
                Debug.Log("6 - Card Fragment");
                RewardText.text = "You got a Card Fragment!";
                PlayerScript.CardFragmentCollected();
                break;

            case 270:
                Debug.Log("7 - 1 Gold");
                RewardText.text = "You got 1 Gold!";
                PlayerScript.Coin++;
                break;

            case 315:
                Debug.Log("8 - Nothing");
                RewardText.text = "You got Nothing! :(";
                break;
        }


        coroutineAllowed = true;
    }

    public void Back()
    {
        WheelOfFortuneUI.SetActive(false);
    }

}