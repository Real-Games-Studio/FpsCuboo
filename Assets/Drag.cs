using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    public bool block = false;
    public void DragHandler(BaseEventData data) {
        if(block == false) {
            PointerEventData pointerData = (PointerEventData)data;

            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position);

            transform.position = canvas.transform.TransformPoint(position);
        }
    }

    public void BlockOnTarget(Transform t) {
        block = true;
        transform.position = t.position;
        Debug.Log("blocked");
    }
}
