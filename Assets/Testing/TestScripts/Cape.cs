using UnityEngine;

public class Cape : MonoBehaviour
{
    public GameObject Quest;

    //when the player overlaps with the cape, pick it up and put it in the inventory. 
    //update quest info
    //when the player talks to the npc again, complete quest
    //enable card fragment for the player to pick up
    public void OnTriggerEnter(Collider other)
    {
        Quest.GetComponent<QuestManager>().CapeQuestUpdate();
        Destroy(gameObject);
    }
}
