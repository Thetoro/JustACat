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
    private GameObject cigarette;
    [SerializeField]
    private GameObject beer;

    [SerializeField]
    private LivingRoomInventory inventory;

    private static int timesUsed_catFood = 3;

    public static int TimesUsed_catFood { get => timesUsed_catFood; set => timesUsed_catFood = value; }

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
        switch (timesUsed_catFood)
        { 
            case 0:
                spriteRe_CatFood.sprite = sprites_CatFood[0];
                timesUsed_catFood = 3;
                inventario_CatFood.comprados--;
                catFood.SetActive(false);
                break;
                
            case 1:
                spriteRe_CatFood.sprite = sprites_CatFood[2];
                break;

            case 2:
                spriteRe_CatFood.sprite = sprites_CatFood[1];
                break;
            
            default: 
                break;
        }
    }

    public void CigaretteSystem()
    { 
    
    }

    public void BeerSystem()
    {
        
    }

    private void EstadoActual()
    {

        //Comida para el gato
        switch (timesUsed_catFood)
        {
            case 0:
                spriteRe_CatFood.sprite = sprites_CatFood[0];
                timesUsed_catFood = 3;
                catFood.SetActive(false);
                break;

            case 1:
                spriteRe_CatFood.sprite = sprites_CatFood[2];
                break;

            case 2:
                spriteRe_CatFood.sprite = sprites_CatFood[1];
                break;

            default:
                break;
        }
    }

}
