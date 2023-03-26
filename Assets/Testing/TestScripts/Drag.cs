using UnityEngine;
using UnityEngine.EventSystems;

//script used for the 'put the card fragments together' mechanic
//script from https://www.youtube.com/watch?v=sXTAzcxNqv0&ab_channel=SunnyValleyStudio 
public class Drag : MonoBehaviour
{
    public Canvas canvas;

    public bool AbleToDrag = true;

    public string Position;

    public Vector3 GoalPosition;

    public void DragHandler(BaseEventData data)
    {
        if(AbleToDrag)
        {
            PointerEventData pointerData = (PointerEventData)data;

            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

            transform.position = canvas.transform.TransformPoint(position);

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.name == Position)
        {
            AbleToDrag = false;

        }
    }
}