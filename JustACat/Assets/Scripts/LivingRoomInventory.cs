using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomInventory : MonoBehaviour
{
    [SerializeField]
    private InventorySO[] inventario;

    private bool catFoodOwn;
    private bool catCastleOwn;
    private bool gameOwn;
    private bool paintOwn;
    private bool cigaretteOwn;
    private bool beerOwn;

    public bool CatFoodOwn { get => catFoodOwn; }
    public bool CatCastleOwn { get => catCastleOwn; }
    public bool GameOwn { get => gameOwn; }
    public bool PaintOwn { get => paintOwn; }
    public bool CigaretteOwn { get => cigaretteOwn; }
    public bool BeerOwn { get => beerOwn; }

    // Start is called before the first frame update
    void Start()
    {
        HayEnExistencia();
    }

    public void HayEnExistencia()
    {
        for (int i = 0; i < inventario.Length; i++)
        {
            int id = inventario[i].id;
            switch (id)
            { 
                case 0:
                    if (inventario[i].comprados > 0)
                        catFoodOwn = true;
                    else
                        catFoodOwn = false;
                    break;
                case 1:
                    if (inventario[i].comprados > 0)
                        catCastleOwn = true;
                    else 
                        catCastleOwn = false;
                    break;
                case 2:
                    if (inventario[i].comprados > 0)
                        gameOwn = true;
                    else
                        gameOwn = false;
                    break;
                case 3:
                    if (inventario[i].comprados > 0)
                        paintOwn = true;
                    else 
                        paintOwn = false;
                    break;
                case 4:
                    if (inventario[i].comprados > 0)
                        cigaretteOwn = true;
                    else
                        cigaretteOwn = false;
                    break;
                case 5:
                    if (inventario[i].comprados > 0)
                        beerOwn = true;
                    else
                        beerOwn = false;
                    break;
            }
        }
    }
   
}
