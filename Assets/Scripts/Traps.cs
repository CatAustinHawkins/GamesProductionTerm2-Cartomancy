using UnityEngine;

//script on all traps
public class Traps : MonoBehaviour
{
    public float timer; //float to control time

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Trap"); //Find GameObjects in the scene labelled with the tag 'Trap'

        if (objs.Length > 1) //if there is more than one GameObject with the tag 'Trap' in the scene
        {
            Destroy(gameObject); //destory the current GameObject - to ensure that there is only one Trap in the scene.
        }
    }

    void FixedUpdate()
    {
        timer = timer + 1 * Time.deltaTime; //add to the timer

        if (timer > 5) //after more than 5 seconds
        {
            Destroy(gameObject); //destory the trap so the player can place another
        }
    }
}
