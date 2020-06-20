using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragMove : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector2 pivot;
    public Vector2 prePos;
    public Vector2 dir;
    public float mag;
    public float treshhold = 100f;

    public void OnPointerDown(PointerEventData eventData)
    {
        pivot = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dir = eventData.position - pivot;
        mag = dir.magnitude;
        dir.Normalize();
        pivot = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dir = Vector2.zero;
    }
}