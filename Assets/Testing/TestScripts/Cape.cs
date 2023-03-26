using UnityEngine;

//script on the red cape that the player has to collect for a quest

public class Cape : MonoBehaviour
{
    public GameObject Quest; //to be able to get the questmanager scripts function

    public void OnTriggerEnter(Collider other) //when something collides with the object
    {
        Quest.GetComponent<QuestManager>().CapeQuestUpdate(); //trigger the CapeQuestUpdate function on the questmanager, which updates the text shown on the quest menu
        Destroy(gameObject); //removes the cape object from the scene, as it has been collected.
    }
}
