using UnityEngine;

//On the QuestManager object
public class QuestManager : MonoBehaviour
{
    public GameObject QuestBox;

    public GameObject Quest1;

    public bool questopen = false;

    public float timer;
    public bool timergo;

    private void FixedUpdate()
    {
        if (timergo)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > 0.5f)
        {
            timergo = false;
            timer = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (questopen && timergo == false)
            {
                QuestBox.SetActive(false);
                questopen = false;
                timergo = true;
            }

            if (questopen == false && timergo == false)
            {
                QuestBox.SetActive(true);
                questopen = true;
                timergo = true;
            }
        }
    }

    public void Quest1Complete()
    {
        Quest1.SetActive(false);
    }

}
