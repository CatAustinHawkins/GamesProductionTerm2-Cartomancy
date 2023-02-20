using UnityEngine;

public class CardRotation : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            gameObject.transform.Rotate(1.3f, 0, 0);
        }

        if (Input.GetKey(KeyCode.G))
        {
            gameObject.transform.Rotate(0, 1.3f, 0);
        }

        if (Input.GetKey(KeyCode.H))
        {
            gameObject.transform.Rotate(0, 0, 1.3f);
        }

        if(Input.GetKey(KeyCode.R))
        {
            if(cam.fieldOfView < 80)
            {
                cam.fieldOfView++;
            }
        }

        if (Input.GetKey(KeyCode.Y))
        {
            cam.fieldOfView--;
        }
    }
}
