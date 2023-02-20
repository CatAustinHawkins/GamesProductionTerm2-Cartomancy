using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    public GameObject Trap;

    public int Coin;
    public TextMeshProUGUI CoinText;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public int Health;

    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 40;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string yAxis = "Mouse Y";

    void Update()
    {
        //https://gist.github.com/KarlRamstedt/407d50725c7b6abeaf43aee802fdd88e
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, 0.05f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-0.05f, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, 0, -0.05f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(0.05f, 0, 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.Translate(0, 0.3f, 0);
        }

        if(Input.GetKey(KeyCode.T))
        {
            Instantiate(Trap, gameObject.transform.position, gameObject.transform.rotation);
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
