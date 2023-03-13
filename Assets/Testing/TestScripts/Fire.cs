using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool PlayerOverlapping;
    public GameObject Player;

    public void Update()
    {
        if(PlayerOverlapping)
        {
            if(Input.GetKey(KeyCode.F))
            {
                Player.GetComponent<Player>().FirePutOut();
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerOverlapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerOverlapping = false;
    }
}
