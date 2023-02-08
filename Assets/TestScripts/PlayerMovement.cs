using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, 0.05f);
        }

        if(Input.GetKey(KeyCode.A))
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
    }
}
