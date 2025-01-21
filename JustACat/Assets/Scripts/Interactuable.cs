using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Interactuable : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]
    private TimeManager timeManager;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    { 
        if(!ctx.started)
            return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if(!rayHit.collider)
            return;

        Debug.Log(rayHit.collider.gameObject.name);
        Accion(rayHit.collider.gameObject.name);
    }

    private void Accion(string objetoNombre) 
    {
        switch (objetoNombre) 
        {
            case "Clock":
                timeManager.CambiarEtapa();
                break;

            case "Door":
                SceneManager.LoadScene("Store");
                break;
        }
    }
}
