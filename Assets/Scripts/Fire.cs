using UnityEngine;

//script on each fire the player has to put out

public class Fire : MonoBehaviour
{
    public GameObject Player; //get the player gameobject, to access its functions

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<Player>().FirePutOut(); //trigger the FirePutOut function on the player
        Destroy(gameObject); //destory the fire gameobject
    }

}
