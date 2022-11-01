using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField]
    private Canvas canvasRef;

    private RectTransform rectTrans;
    private CanvasGroup canvasGroupRef;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroupRef = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        rectTrans.anchoredPosition += eventData.delta / canvasRef.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroupRef.alpha = .6f;
        canvasGroupRef.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroupRef.alpha = 1f;
        canvasGroupRef.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
