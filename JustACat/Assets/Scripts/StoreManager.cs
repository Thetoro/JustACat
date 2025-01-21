using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoreManager : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private int dinero;
    [SerializeField]
    private GameObject castilloAgotado;
    [SerializeField]
    private GameObject juegoAgotado;
    [SerializeField]
    private GameObject pinturaAgotado;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider)
            return;

        Debug.Log(rayHit.collider.gameObject.name);
        //Accion(rayHit.collider.gameObject.name);
    }

    private void Accion(string objetoNombre)
    {
        int precio = 0;
        switch (objetoNombre)
        {
            case "CatFood":
                precio = 50;
                Comprar(precio);
                break;

            case "CatCastle":
                precio = 200;
                Comprar(precio);
                if (precio < dinero)
                    castilloAgotado.SetActive(true);
                break;

            case "Game":
                precio = 70;
                Comprar(precio);
                if (precio < dinero)
                    juegoAgotado.SetActive(true);
                break;

            case "Paint":
                precio = 250;
                Comprar(precio);
                if(precio < dinero)
                    pinturaAgotado.SetActive(true);
                break;

            case "Cigarette":
                precio = 20;
                Comprar(precio);
                break;

            case "Beer":
                precio = 25;
                Comprar(precio);
                break;
        }
    }

    private void Comprar(int precio)
    {
        if (precio < dinero)
        {
            dinero = dinero - precio;
        }
        else { 
            //Sonido negativo
        }

    }
}
