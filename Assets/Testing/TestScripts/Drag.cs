using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    public Canvas canvas;



    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,pointerData.position,canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}