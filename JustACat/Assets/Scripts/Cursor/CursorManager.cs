using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance { get; private set; }

    [SerializeField]
    private Texture2D cursorCollision;
    [SerializeField]
    private Texture2D cursorDefault;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

    public void SetCursorTexture(CursorTexture cursorTexture)
    {
        switch (cursorTexture)
        {
            case CursorTexture.Default:
                Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
                break;
            
            case CursorTexture.Pointing:
                Cursor.SetCursor(cursorCollision, Vector2.zero, CursorMode.Auto);
                break;

            default:
                Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
                break;
        }
    }

    
}

public enum CursorTexture
{
    Default,
    Pointing
}
