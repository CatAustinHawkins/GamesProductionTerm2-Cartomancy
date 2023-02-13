using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.001f;

    public Transform MoveToPosition;

    public GameObject player;

    public bool TrapInSight;
    public bool PlayerInSight = false;

    public GameObject[] Trap;

    void Awake()
    {
        PlayerInSight = false;
    }

    void Update()
    {

        Trap = GameObject.FindGameObjectsWithTag("Trap");

        if (Trap.Length == 0)
        {
            TrapInSight = false;
        }


        if (PlayerInSight)
        {
            MoveToPosition = player.transform;
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MoveToPosition.position, step);
            MoveToPosition = player.transform;
        }

        if(TrapInSight)
        {
            MoveToPosition = Trap[0].transform;
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MoveToPosition.position, step);
            MoveToPosition = Trap[0].transform;
        }
        Trap = GameObject.FindGameObjectsWithTag("Trap");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trap")
        {
            TrapInSight = true;
            PlayerInSight = false;
            Trap = GameObject.FindGameObjectsWithTag("Trap");

            if (Trap.Length == 1)
            {
                TrapInSight = true;
                MoveToPosition = Trap[0].transform;
            }
        }

        if (other.tag == "Player")
        {
            PlayerInSight = true;
            TrapInSight = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerInSight = false;
        }

        if(other.tag == "Trap")
        {
            TrapInSight = false;
        }
    }
}
