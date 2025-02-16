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
    [SerializeField]
    private ConsumableManager consumableManager;
    [SerializeField]
    private TrashManager trashManager;
    [SerializeField]
    private StatsSO stats;

    private static int cantidadAcciones;

    private bool yaSeUso;

    public bool YaSeUso { get => yaSeUso; set => yaSeUso = value; }

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
        Accion(rayHit.collider.gameObject.name, rayHit.collider.gameObject);
    }

    private void Accion(string objetoNombre, GameObject objeto) 
    {
        cantidadAcciones++;
        switch (objetoNombre) 
        {
            case "Clock":
                timeManager.CambiarEtapa();
                break;

            case "Door":
                SceneManager.LoadScene("Store");
                break;
            
            case "CatFood":
                if(!YaSeUso)
                    consumableManager.FoodSystem();
                yaSeUso = true;
                break;

            case "Cigarette":
                consumableManager.CigaretteSystem();
                break;

            case "Beer":
                consumableManager.BeerSystem();
                break;

            case "TrashCigarette(Clone)":
                trashManager.DestroyTrash(objeto);
                break;

            case "TrashBeer(Clone)":
                trashManager.DestroyTrash(objeto);
                break;

            case "Cat":
                stats.amorGato += 10;
                stats.animo += 10;
                stats.estres -= 10;
                SceneManager.LoadScene("CatMiniGame");
                break;
        }

        if (cantidadAcciones == 3)
        {
            timeManager.CambiarEtapa();
            cantidadAcciones = 0;
        }
    }


}
