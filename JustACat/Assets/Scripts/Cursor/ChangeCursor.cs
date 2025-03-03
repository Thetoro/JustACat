using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ChangeCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private CursorTexture cursorTexture;

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.instance.SetCursorTexture(cursorTexture);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.instance.SetCursorTexture(CursorTexture.Default);
    }

    private void OnMouseEnter()
    {
        CursorManager.instance.SetCursorTexture(cursorTexture);
    }

    private void OnMouseExit()
    {
        CursorManager.instance.SetCursorTexture(CursorTexture.Default);
    }
}
