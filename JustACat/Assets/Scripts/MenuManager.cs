using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private Collider2D[] colliders;

    public void OnPaused(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        if(!menu.activeSelf)
            EnableMenu();
        else if(menu.activeSelf)
            DisableMenu();
    }

    private void EnableMenu()
    {
        menu.SetActive(true);
        foreach (Collider2D collider in colliders) 
        { 
            collider.enabled = false; 
        }
    }

    private void DisableMenu()
    {
        menu.SetActive(false);
        foreach (Collider2D collider in colliders) 
        { 
            collider.enabled = true; 
        }
    }

    public void Resumir()
    {
        DisableMenu();
    }

    public void Salir()
    { 
        Application.Quit();
    }
}
