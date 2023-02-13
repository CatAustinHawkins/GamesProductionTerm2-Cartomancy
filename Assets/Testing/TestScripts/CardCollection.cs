using UnityEngine;

public class CardCollection : MonoBehaviour
{
    public GameObject Card;

    private void OnTriggerEnter(Collider other)
    {
        Card.SetActive(true);
        Destroy(gameObject);
    }
}
