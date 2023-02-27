using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            //transform.position = canvas.transform.TransformPoint(GoalPosition);

            AbleToDrag = false;
        }
    }
}