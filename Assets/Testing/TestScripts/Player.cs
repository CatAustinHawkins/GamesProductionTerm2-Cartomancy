using UnityEngine;
using TMPro;

//script on the player gameobject
public class Player : MonoBehaviour
{
    [Header("Trap")]
    public GameObject Trap; //Trap Prefab that the player can place

    [Header("Coin Info")]
    public int Coin; //track the amount of coins the player has
    public TextMeshProUGUI CoinText; //display the amount of coins the player has

    [Header("Heart and Health Info")]
    public GameObject Heart1; 
    public GameObject Heart2;
    public GameObject Heart3;
    public int Health;

    //code from https://gist.github.com/KarlRamstedt/407d50725c7b6abeaf43aee802fdd88e
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 40; //was originally 88f, changed to 40f so the player has more limited vision - looks better and smoother than the previous yRotationLimit. 

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; 
    const string yAxis = "Mouse Y";

    void FixedUpdate()
    {
        //code from https://gist.github.com/KarlRamstedt/407d50725c7b6abeaf43aee802fdd88e
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat; //change the rotation of the player - which is the parent of the camera. 

        if (Input.GetKey(KeyCode.W)) //when W pressed
        {
            gameObject.transform.Translate(0, 0, 0.05f); //move the player in the z axis by 0.05f
        }

        if (Input.GetKey(KeyCode.A)) //when A pressed
        {
            gameObject.transform.Translate(-0.05f, 0, 0); //move the player in the x axis by -0.05f
        }

        if (Input.GetKey(KeyCode.S)) //when S pressed
        {
            gameObject.transform.Translate(0, 0, -0.05f); //move the player in the z axis by -0.05f
        }

        if (Input.GetKey(KeyCode.D)) //when D pressed
        {
            gameObject.transform.Translate(0.05f, 0, 0); //move the player in the x axis by 0.05f
        }

        if(Input.GetKey(KeyCode.Space)) //when Space pressed
        {
            gameObject.transform.Translate(0, 0.3f, 0); //move the player in the y axis by 0.3f
        }

        if(Input.GetKey(KeyCode.T))
        {
            Instantiate(Trap, gameObject.transform.position, gameObject.transform.rotation); //place a trap, in the same position and rotation and the player
        }
    }


    public void OnCoinCollection()
    {
        Coin++;
        CoinText.text = Coin.ToString();
    }

    public void HealthDecrease()
    {
        switch(Health)
        {
            case 3:
                Heart1.SetActive(false);
                Health--;
                break;
            case 2:
                Heart2.SetActive(false);
                Health--;
                break;
            case 1:
                Heart3.SetActive(false);
                Health--;
                break;
        }
    }
}
