using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.001f;

    public Transform MoveToPosition;

    public GameObject player;

    public bool TrapInSight;
    public bool PlayerInSight = false;

    public GameObject[] Trap;

    public float timer;
    public bool timeractive;


    void Awake()
    {
        PlayerInSight = false;
    }

    void Update()
    {
        if (timeractive)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if(timer > 1f)
        {
            timeractive = false;
        }

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

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if(collision.gameObject.tag == "Player" && timeractive == false)
        {
            timeractive = true;
            player.GetComponent<Player>().HealthDecrease();
        }

        if(collision.gameObject.tag == "Trap")
        {
            TrapInSight = false;
            //so the enemy stops when it touches the trap
        }
    }
}
