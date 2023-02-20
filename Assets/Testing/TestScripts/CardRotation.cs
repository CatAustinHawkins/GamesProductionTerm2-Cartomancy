using UnityEngine;

//script on rotatable objects
public class CardRotation : MonoBehaviour
{
    [Header("The Camera")]
    public Camera cam; //the camera

    void FixedUpdate()
    {
        //when the player presses F
        if (Input.GetKey(KeyCode.F))
        {
            gameObject.transform.Rotate(1.3f, 0, 0); //rotate the object in the x
        }

        //when the player presses G
        if (Input.GetKey(KeyCode.G))
        {
            gameObject.transform.Rotate(0, 1.3f, 0);
        }

        //when the player presses H
        if (Input.GetKey(KeyCode.H))
        {
            gameObject.transform.Rotate(0, 0, 1.3f);
        }

        //when the player presses R
        if(Input.GetKey(KeyCode.R))
        {
            if(cam.fieldOfView < 80) //check what the cameras field of view value is, if below 80 then
            {
                //increase the field of view - zooming into the object
                cam.fieldOfView++;
            }
        }

        //when the player presses Y
        if (Input.GetKey(KeyCode.Y))
        {
            //decrease the field of view - zooming out of the object
            cam.fieldOfView--;
        }
    }
}
