using UnityEngine;

//on each NPC character
public class NPC : MonoBehaviour
{

    public GameObject Dialogue;

    public GameObject DialogueBox;

    public Dialogue DialogueScript;

    public bool dialogueopen = false;

    public float timer;
    public bool timergo;

    public bool PlayerInTrigger;

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

        if(PlayerInTrigger)
        {
            if (Input.GetKey(KeyCode.E) && dialogueopen == false && timergo == false)
            {
                DialogueBox.SetActive(true);
                DialogueScript.NewText = "This is a test.";
                Dialogue.GetComponent<Dialogue>().DialogueTrigger();
                DialogueScript.NPCCounter = 1;
                dialogueopen = true;
                timergo = true;
            }

            if (Input.GetKey(KeyCode.E) && dialogueopen && timergo == false)
            {
                DialogueBox.SetActive(false);
                dialogueopen = false;
                timergo = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerInTrigger = true;
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerInTrigger = false;
        DialogueBox.SetActive(false);
        dialogueopen = false;
    }
}
