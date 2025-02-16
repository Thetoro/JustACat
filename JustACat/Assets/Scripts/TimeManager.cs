using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] colorlessClockSprite;
    [SerializeField]
    private Sprite[] colorClockSprite;
    [SerializeField]
    private Sprite[] colorlessCalendarSprite;
    [SerializeField]
    private Sprite[] colorCalendarSprite;

    [SerializeField]
    private TiempoSO tiempoGuardado;

    [SerializeField]
    private SpriteRenderer colorlessGameClock;
    [SerializeField]
    private SpriteRenderer colorGameClock;
    [SerializeField]
    private SpriteRenderer colorlessGameCalendar;
    [SerializeField]
    private SpriteRenderer colorGameCalendar;

    [SerializeField]
    private CatBehaviour gato;
    [SerializeField]
    private ConsumableManager consumableManager;
    [SerializeField]
    private LivingRoomInventory inventory;
    [SerializeField]
    private Interactuable interactuable;
    [SerializeField]
    private SueldoSO sueldo;
    [SerializeField]
    private StatsSO stats;
    [SerializeField]
    private StatsManager statsManager;
    [SerializeField]
    private TrashManager trashManager;

    [SerializeField]
    private SpriteRenderer spriteRe_FoodPlate;
    [SerializeField]
    private Sprite sprite_FoodPlate;

    // Start is called before the first frame update
    void Start()
    {
        //Cambio de reloj
        colorlessGameClock.sprite = colorlessClockSprite[(int)tiempoGuardado.etapaGuardada];
        colorGameClock.sprite = colorClockSprite[(int)tiempoGuardado.etapaGuardada];
        //Cambio de calendario
        colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
        colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
    }

    public void CambiarEtapa()
    {
        int i = (int)tiempoGuardado.etapaGuardada;

        switch (i)
        {
            case 0:
                if (tiempoGuardado.diaGuardado == TiempoSO.Dias.Domingo || tiempoGuardado.diaGuardado == TiempoSO.Dias.Sabado)
                    tiempoGuardado.etapaGuardada = TiempoSO.EtapasDia.Noon;
                else
                {
                    tiempoGuardado.etapaGuardada = TiempoSO.EtapasDia.Afternoon;
                    stats.animo -= 30;
                    stats.estres += 30;
                    statsManager.ActualizarAnimo = true;
                    statsManager.ActualizarEstres = true;

                }
                colorlessGameClock.sprite = colorlessClockSprite[(int)tiempoGuardado.etapaGuardada];
                colorGameClock.sprite = colorClockSprite[(int)tiempoGuardado.etapaGuardada];
                gato.ColocarAlGato();
                break;

            case 1:
                tiempoGuardado.etapaGuardada = TiempoSO.EtapasDia.Afternoon;
                colorlessGameClock.sprite = colorlessClockSprite[(int)tiempoGuardado.etapaGuardada];
                colorGameClock.sprite = colorClockSprite[(int)tiempoGuardado.etapaGuardada];
                gato.ColocarAlGato();
                if (tiempoGuardado.diaGuardado == TiempoSO.Dias.Viernes)
                    sueldo.sueldo += 100;
                break;

            case 2:
                tiempoGuardado.etapaGuardada = TiempoSO.EtapasDia.Night;
                colorlessGameClock.sprite = colorlessClockSprite[(int)tiempoGuardado.etapaGuardada];
                colorGameClock.sprite = colorClockSprite[(int)tiempoGuardado.etapaGuardada];
                gato.ColocarAlGato();
                break;

            case 3:
                tiempoGuardado.etapaGuardada = TiempoSO.EtapasDia.Morning;
                if (!trashManager.IsClean())
                {
                    Debug.Log("Sucio");
                    stats.estres += 2;
                    stats.animo -= 2;
                }
                colorlessGameClock.sprite = colorlessClockSprite[(int)tiempoGuardado.etapaGuardada];
                colorGameClock.sprite = colorClockSprite[(int)tiempoGuardado.etapaGuardada];
                gato.ColocarAlGato();
                CambiarDia();
                break;
        }

    }

    private void CambiarDia()
    {
        int i = (int)tiempoGuardado.diaGuardado;
        inventory.HayEnExistencia();
        consumableManager.AppearIfOwn();
        spriteRe_FoodPlate.sprite = sprite_FoodPlate;
        interactuable.YaSeUso = false;
        if (!consumableManager.CatFoodUsed)
            stats.amorGato -= 10;
        else
            consumableManager.CatFoodUsed = false;
        switch (i)
        {
            case 0:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Martes;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;

            case 1:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Miercoles;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;

            case 2:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Jueves;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;

            case 3:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Viernes;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;

            case 4:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Sabado;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;

            case 5:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Domingo;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;

            case 6:
                tiempoGuardado.diaGuardado = TiempoSO.Dias.Lunes;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)tiempoGuardado.diaGuardado];
                colorGameCalendar.sprite = colorCalendarSprite[(int)tiempoGuardado.diaGuardado];
                break;
        }
    }
}
