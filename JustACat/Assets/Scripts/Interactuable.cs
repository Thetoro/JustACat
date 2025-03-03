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
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;

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
        
        switch (objetoNombre) 
        {
            case "Clock":
                timeManager.CambiarEtapa();
                break;

            case "Door":
                cantidadAcciones++;
                StartCoroutine(DoorBehaviour());
                break;
            
            case "CatFood":
                if (!YaSeUso)
                {
                    StartCoroutine(CatFoodBehaviour());
                }
                yaSeUso = true;
                break;

            case "Cigarette":
                consumableManager.CigaretteSystem();
                audioSource.PlayOneShot(audioClip[1]);
                break;

            case "Beer":
                consumableManager.BeerSystem();
                audioSource.PlayOneShot(audioClip[2]);
                break;

            case "TrashCigarette(Clone)":
                cantidadAcciones++;
                trashManager.DestroyTrash(objeto);
                break;

            case "TrashBeer(Clone)":
                cantidadAcciones++;
                trashManager.DestroyTrash(objeto);
                break;

            case "Cat":
                cantidadAcciones++;
                stats.amorGato += 10;
                stats.animo += 10;
                stats.estres -= 10;
                Debug.Log("Hola");
                SceneManager.LoadScene("CatMiniGame");
                break;
        }

        if (cantidadAcciones == 3)
        {
            timeManager.CambiarEtapa();
            cantidadAcciones = 0;
        }
    }

    private IEnumerator DoorBehaviour()
    {
        audioSource.PlayOneShot(audioClip[0]);
        yield return new WaitForSeconds(audioClip[0].length);
        SceneManager.LoadScene("Store");
    }

    private IEnumerator CatFoodBehaviour()
    {
        audioSource.PlayOneShot(audioClip[3]);
        yield return new WaitForSeconds(audioClip[3].length);
        consumableManager.FoodSystem();
        
    }


}
