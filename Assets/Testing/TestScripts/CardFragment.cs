using UnityEngine;

public class CardFragment : MonoBehaviour
{
    public int CardFragmentNumber;

    public GameObject CardFragmentImage;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CardFragmentImage.SetActive(true);
            Destroy(gameObject);
        }
    }

}
