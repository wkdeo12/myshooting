using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    //public JoyStick JoyStick;
    public Image treshold;

    public Image touch;

    public Vector3 Vector;

    public bool shoot;

    public bool State;

    private RectTransform rectTransform;

    private void Start()
    {
        Vector = Vector3.zero;
        State = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(treshold.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out position)) ;
        {
            position.x = (position.x / treshold.rectTransform.sizeDelta.x);
            position.y = (position.y / treshold.rectTransform.sizeDelta.y);

            float x = (treshold.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (treshold.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

            Vector = new Vector3(x, y, 0);
            Vector = (Vector.magnitude > 1) ? Vector.normalized : Vector;

            touch.rectTransform.anchoredPosition = new Vector3(Vector.x * (treshold.rectTransform.sizeDelta.x / 2.5f),
                Vector.y * (treshold.rectTransform.sizeDelta.y / 2.5f));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector = Vector3.zero;
        treshold.rectTransform.anchoredPosition = Vector3.zero;
        touch.rectTransform.anchoredPosition = Vector3.zero;
        State = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        State = true;
        treshold.transform.position = eventData.position;
    }
}