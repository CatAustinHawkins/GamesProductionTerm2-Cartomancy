using UnityEngine;

public class Crown : MonoBehaviour
{

    public GameObject Quest;

    public void OnTriggerEnter(Collider other)
    {
        Quest.GetComponent<QuestManager>().CrownQuestUpdate();
        Destroy(gameObject);
    }

}
