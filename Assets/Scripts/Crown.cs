using UnityEngine;

//script on the crown object that the player has to collect for a quest

public class Crown : MonoBehaviour
{
    public GameObject Quest; //get the quest gameobject, in order to access the questmanager script and its functions

    public void OnTriggerEnter(Collider other)
    {
        Quest.GetComponent<QuestManager>().CrownQuestUpdate(); //trigger the crown quest update function on the questmanager script - to update the text on the quest menu
        Destroy(gameObject); //remove the crown gameobject from the scene
    }

}
