using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : MonoBehaviour
{
    public bool PlayerOverlapping;

    public float timer;

    public GameObject FishingPool;

    public void FixedUpdate()
    {
        timer = timer + 1 * Time.deltaTime;

        if(timer > 5)
        {
            gameObject.SetActive(false);
        }

        if(PlayerOverlapping)
        {
            if(Input.GetKey(KeyCode.F))
            {
                FishingPool.GetComponent<Fishing>().Fished();
                gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerOverlapping = true;
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerOverlapping = false;
    }
}
