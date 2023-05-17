using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Float")]
    public float speed = 0.001f; //the speed that the enemy moves
    public float step; //controls how fast the enemy moves, using the speed float and Time.deltatTime

    [Header("Transform")]
    public Transform MoveToPosition; //where the enemy is travelling to

    [Header("GameObjects")]
    public GameObject player; //the Player
    public GameObject[] Trap; //an array of Trap GameObject

    [Header("Booleans")]
    public bool TrapInSight; //controls whether the enemy is seeing a trap or not
    public bool PlayerInSight = false; //controls whether the enemy is seeing the player or not

    [Header("Timers")]
    public bool timeractive; //when true, the timer begins
    public float timer; //float 

    public AudioSource audio;

    void Awake()
    {
        PlayerInSight = false; //setting PlayerInSight to false as it kept getting enabled at the start of playing 
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //start the timer
        if (timeractive)
        {
            //add to the timer
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > 1f) //if more than 1 second has passed
        {
            timeractive = false; //stop the timer
        }

        Trap = GameObject.FindGameObjectsWithTag("Trap"); //find objects with the 'Trap' tag, and add them to the Trap array

        if (Trap.Length == 0) //if there are no traps in the scene
        {
            TrapInSight = false; //set TrapInSight to false
        }


        if (PlayerInSight)//if PlayerInSight is true, so the enemy can see the player
        {
            MoveToPosition = player.transform; //MoveToPosition is set to the position of the player
            step = speed * Time.deltaTime; //calculation to determine how fast the enemy moves
            transform.position = Vector3.MoveTowards(transform.position, MoveToPosition.position, step); //make the enemy move towards the player
            MoveToPosition = player.transform; //MoveToPosition is set to the position of the player
        }

        if(TrapInSight)//if PlayerInSight is true, so the enemy can see a trap
        {
            MoveToPosition = Trap[0].transform; //MoveToPosition is set to the position of the first Trap in the array
            step = speed * Time.deltaTime; //calculation to determine how fast the enemy moves
            transform.position = Vector3.MoveTowards(transform.position, MoveToPosition.position, step); //make the enemy move towards the trap
            MoveToPosition = Trap[0].transform; //MoveToPosition is set to the position of the player
        }

        Trap = GameObject.FindGameObjectsWithTag("Trap"); //find objects with the 'Trap' tag, and add them to the Trap array
    }

    public void OnTriggerEnter(Collider other) //when an object enters the enemies trigger
    {
        if(other.tag == "Trap") //if the object the enemy collides with is tagged with Trap
        {
            TrapInSight = true; //enable TrapInSight so the enemy starts following the trap
            PlayerInSight = false; //disable PlayerInSight so the enemy stops following the player
            Trap = GameObject.FindGameObjectsWithTag("Trap"); //find GameObjects in the scene tagged with Trap and add them to the array

            if (Trap.Length == 1) //if there is 1 object in the Trap array
            {
                TrapInSight = true; //enable TrapInSight
                MoveToPosition = Trap[0].transform; //Set the MoveToPosition to the first trap in the array
            }
        }

        if (other.tag == "Player") //if the object the enemy collides with is tagged with Player
        {
            PlayerInSight = true; //set PlayerInSight to true, so the enemy moves towards the player
            TrapInSight = false; //set TrapInSight to false, so the enemy stops moving towards the trap
        }
    }

    private void OnTriggerExit(Collider other) //when an object exits the enemies trigger
    {
        if(other.tag == "Player") //if the object leaving the collision is tagged with Player
        {
            PlayerInSight = false; //set PlayerInSight to false, so the enemy stops moving towards the trap
        }

        if(other.tag == "Trap") //if the object leaving the collision is tagged with Trap
        {
            TrapInSight = false; //set TrapInSight to false, so the enemy stops moving towards the trap
        }
    }

    public void OnCollisionEnter(Collision collision) //when an object enters the enemies collider
    {
        Debug.Log("Collided");
        if(collision.gameObject.tag == "Player" && timeractive == false) //if the object the enemy has collided with is tagged with Player, and if the timer is not active
        {
            timeractive = true; //enable the timer - this stops the player from being instantly killed
            player.GetComponent<Player>().HealthDecrease(); //Call to the HealthDecrease function in the Player script
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }

        if(collision.gameObject.tag == "Trap") //if the object the enemy has collided with is tagged with Trap
        {
            TrapInSight = false; //Disabling the TrapInSight, so the enemy stops when it touches the trap
        }
    }
}
