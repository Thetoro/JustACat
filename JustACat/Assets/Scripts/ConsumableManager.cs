using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    [SerializeField]
    private GameObject catFood;
    [SerializeField]
    private InventorySO inventario_CatFood;
    [SerializeField]
    private SpriteRenderer spriteRe_CatFood;
    [SerializeField]
    private Sprite[] sprites_CatFood;
    [SerializeField]
    private GameObject foodPlate;
    [SerializeField]
    private SpriteRenderer spriteRe_FoodPlate;
    [SerializeField]
    private Sprite sprites_FoodPlate;
    [SerializeField]
    private GameObject cigarette;
    [SerializeField]
    private InventorySO inventario_Cigarette;
    [SerializeField]
    private GameObject beer;
    [SerializeField]
    private InventorySO inventario_Beer;
    [SerializeField]
    private SpriteRenderer spriteRe_Beer;
    [SerializeField]
    private Sprite[] sprites_Beer;

    [SerializeField]
    private LivingRoomInventory inventory;
    [SerializeField]
    private StatsManager statsManager;
    [SerializeField]
    private TrashManager trashManager;

    [SerializeField]
    private StatsSO stats;

    private static int timesUsed_catFood = 3;
    private static int timesUsed_cigarettes = 4;
    private static int timesUsed_beer = 6;

    private bool catFoodUsed;

    public bool CatFoodUsed { get => catFoodUsed; set => catFoodUsed = value; }

    // Start is called before the first frame update
    void Start()
    {
        AppearIfOwn();
        
    }

    public void AppearIfOwn()
    {
       
        if(inventory.CatFoodOwn && !catFood.activeSelf)
            catFood.SetActive(true);
        else if(!inventory.CatFoodOwn && catFood.activeSelf)
            catFood.SetActive(false);

        if(inventory.CatFoodOwn && !foodPlate.activeSelf)
            foodPlate.SetActive(true);

        if(inventory.CigaretteOwn && !cigarette.activeSelf)
            cigarette.SetActive(true);
        else if(!inventory.CigaretteOwn && cigarette.activeSelf)
            cigarette.SetActive(false);

        if(inventory.BeerOwn && !beer.activeSelf)
            beer.SetActive(true);
        else if (!inventory.BeerOwn && beer.activeSelf)
            beer.SetActive(false);
        
        EstadoActual();
    }

    public void FoodSystem()
    {
        timesUsed_catFood--;
        catFoodUsed = true;
        switch (timesUsed_catFood)
        { 
            case 0:
                spriteRe_CatFood.sprite = sprites_CatFood[0];
                timesUsed_catFood = 3;
                inventario_CatFood.comprados--;
                stats.amorGato += 2;
                statsManager.ActualizarGato = true;
                spriteRe_FoodPlate.sprite = sprites_FoodPlate;
                catFood.SetActive(false);
                break;
                
            case 1:
                spriteRe_CatFood.sprite = sprites_CatFood[2];
                stats.amorGato += 2;
                statsManager.ActualizarGato = true;
                spriteRe_FoodPlate.sprite = sprites_FoodPlate;
                break;

            case 2:
                spriteRe_CatFood.sprite = sprites_CatFood[1];
                stats.amorGato += 2;
                statsManager.ActualizarGato = true;
                spriteRe_FoodPlate.sprite = sprites_FoodPlate;
                break;
            
            default: 
                break;
        }
    }

    public void CigaretteSystem()
    {
        timesUsed_cigarettes--;
        stats.estres -= 5;
        stats.amorGato -= 3;
        statsManager.ActualizarGato = true;
        statsManager.ActualizarAnimo = true;
        statsManager.ActualizarEstres = true;
        if (timesUsed_cigarettes == 0)
        {
            timesUsed_cigarettes = 4;
            inventario_Cigarette.comprados--;
            trashManager.SpawnTrashCigarette();
            cigarette.SetActive(false);
        }
    }

    public void BeerSystem()
    {
        timesUsed_beer--;
        trashManager.SpawnTrashBeer();
        switch (timesUsed_beer)
        {
            case 0:
                spriteRe_Beer.sprite = sprites_Beer[0];
                timesUsed_beer = 6;
                inventario_Beer.comprados--;
                stats.estres -= 4;
                stats.animo += 5;
                statsManager.ActualizarAnimo = true;
                statsManager.ActualizarEstres = true;
                beer.SetActive(false);
                break;

            case 1:
                spriteRe_Beer.sprite = sprites_Beer[5];
                stats.estres -= 4;
                stats.animo += 5;
                statsManager.ActualizarAnimo = true;
                statsManager.ActualizarEstres = true;
                break;

            case 2:
                spriteRe_Beer.sprite = sprites_Beer[4];
                stats.estres -= 4;
                stats.animo += 5;
                statsManager.ActualizarAnimo = true;
                statsManager.ActualizarEstres = true;
                break;

            case 3:
                spriteRe_Beer.sprite = sprites_Beer[3];
                stats.estres -= 4;
                stats.animo += 5;
                statsManager.ActualizarAnimo = true;
                statsManager.ActualizarEstres = true;
                break;

            case 4:
                spriteRe_Beer.sprite = sprites_Beer[2];
                stats.estres -= 4;
                stats.animo += 5;
                statsManager.ActualizarAnimo = true;
                statsManager.ActualizarEstres = true;
                break;

            case 5:
                spriteRe_Beer.sprite = sprites_Beer[1];
                stats.estres -= 4;
                stats.animo += 5;
                statsManager.ActualizarAnimo = true;
                statsManager.ActualizarEstres = true;
                break;

            default:
                break;
        }
    }

    private void EstadoActual()
    {

        //Comida para el gato
        if (catFood.activeSelf)
        {
            switch (timesUsed_catFood)
            {
                case 0:
                    spriteRe_CatFood.sprite = sprites_CatFood[0];
                    timesUsed_catFood = 3;
                    catFood.SetActive(false);
                    spriteRe_FoodPlate.sprite = sprites_FoodPlate;
                    break;

                case 1:
                    spriteRe_CatFood.sprite = sprites_CatFood[2];
                    spriteRe_FoodPlate.sprite = sprites_FoodPlate;
                    break;

                case 2:
                    spriteRe_CatFood.sprite = sprites_CatFood[1];
                    spriteRe_FoodPlate.sprite = sprites_FoodPlate;
                    break;

                default:
                    break;
            }
        }

        if (beer.activeSelf)
        {
            switch (timesUsed_beer)
            {
                case 0:
                    spriteRe_Beer.sprite = sprites_Beer[0];
                    timesUsed_beer = 6;
                    inventario_Beer.comprados--;
                    beer.SetActive(false);
                    break;

                case 1:
                    spriteRe_Beer.sprite = sprites_Beer[5];
                    break;

                case 2:
                    spriteRe_Beer.sprite = sprites_Beer[4];
                    break;

                case 3:
                    spriteRe_Beer.sprite = sprites_Beer[3];
                    break;

                case 4:
                    spriteRe_Beer.sprite = sprites_Beer[2];
                    break;

                case 5:
                    spriteRe_Beer.sprite = sprites_Beer[1];
                    break;

                default:
                    break;
            }
        }
        
    }

}
