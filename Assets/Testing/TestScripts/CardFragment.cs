using UnityEngine;

public class CardFragment : MonoBehaviour
{
    public int CardFragmentNumber;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
