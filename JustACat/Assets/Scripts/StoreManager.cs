using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private TMP_Text sueldo;

    [SerializeField]
    private SueldoSO dinero;

    [SerializeField]
    private GameObject castilloAgotado;
    [SerializeField]
    private Collider2D castilloCollider;
    [SerializeField]
    private GameObject juegoAgotado;
    [SerializeField] 
    private Collider2D juegoCollider;
    [SerializeField]
    private GameObject pinturaAgotado;
    [SerializeField]
    private Collider2D pinturaCollider;

    [SerializeField]
    private InventorySO catFood;
    [SerializeField]
    private InventorySO catCastle;
    [SerializeField]
    private InventorySO game;
    [SerializeField]
    private InventorySO paint;
    [SerializeField]
    private InventorySO cigarette;
    [SerializeField]
    private InventorySO beer;



    private void Start()
    {
        mainCamera = Camera.main;
        sueldo.text = dinero.sueldo.ToString();
        CheckIfOwn();
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider)
            return;

        Debug.Log(rayHit.collider.gameObject.name);
        Accion(rayHit.collider.gameObject.name);
    }

    private void Accion(string objetoNombre)
    {
        int precio = 0;
        switch (objetoNombre)
        {
            case "CatFood":
                precio = 50;
                Comprar(precio, catFood);
                break;

            case "CatCastle":
                precio = 200;
                Comprar(precio, catCastle);
                if (precio < dinero.sueldo)
                {
                    castilloCollider.enabled = false;
                    castilloAgotado.SetActive(true);
                }
                break;

            case "Game":
                precio = 70;
                Comprar(precio, game);
                if (precio < dinero.sueldo)
                {
                    juegoCollider.enabled = false;
                    juegoAgotado.SetActive(true);
                }
                break;

            case "Paint":
                precio = 250;
                Comprar(precio, paint);
                if (precio < dinero.sueldo)
                {
                    pinturaCollider.enabled = false;
                    pinturaAgotado.SetActive(true);
                }
                break;

            case "Cigarette":
                precio = 20;
                Comprar(precio, cigarette);
                break;

            case "Beer":
                precio = 25;
                Comprar(precio, beer);
                break;
            
            case "ReturnHome":
                SceneManager.LoadScene("LivingRoom");
                break;
        }
    }

    private void Comprar(int precio, InventorySO producto)
    {
        if (precio < dinero.sueldo)
        {
            dinero.sueldo = dinero.sueldo - precio;
            sueldo.text = dinero.sueldo.ToString();
            producto.comprados++;
        }
        else {
            Debug.Log("No se puede comprar");
        }

    }

    private void CheckIfOwn()
    {
        if (catCastle.comprados > 0)
        {
            castilloCollider.enabled = false;
            castilloAgotado.SetActive(true);
        }

        if (game.comprados > 0)
        {
            juegoCollider.enabled = false;
            juegoAgotado.SetActive(true);
        }

        if (paint.comprados > 0)
        {
            pinturaCollider.enabled = false;
            pinturaAgotado.SetActive(true);
        }
    }
}
