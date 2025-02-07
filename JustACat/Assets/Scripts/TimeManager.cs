using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private enum EtapasDia
    {
        Morning,
        Noon,
        Afternoon,
        Night
    }

    private enum Dias
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }

    [SerializeField]
    private Sprite[] colorlessClockSprite;
    [SerializeField]
    private Sprite[] colorClockSprite;
    [SerializeField]
    private Sprite[] colorlessCalendarSprite;
    [SerializeField]
    private Sprite[] colorCalendarSprite;

    [SerializeField]
    private EtapasDia etapa;
    [SerializeField]
    private Dias dias;

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
    private Interactuable interactuable;
    [SerializeField]
    private SueldoSO sueldo;

    // Start is called before the first frame update
    void Start()
    {
        etapa = EtapasDia.Night;
        dias = Dias.Viernes;
        //Cambio de reloj
        colorlessGameClock.sprite = colorlessClockSprite[(int)etapa];
        colorGameClock.sprite = colorClockSprite[(int)etapa];
        //Cambio de calendario
        colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
        colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
    }

    public void CambiarEtapa()
    {
        int i = (int)etapa;

        switch (i)
        {
            case 0:
                etapa = EtapasDia.Noon;
                colorlessGameClock.sprite = colorlessClockSprite[(int)etapa];
                colorGameClock.sprite = colorClockSprite[(int)etapa];
                gato.ColocarAlGato();
                break;

            case 1:
                etapa = EtapasDia.Afternoon;
                colorlessGameClock.sprite = colorlessClockSprite[(int)etapa];
                colorGameClock.sprite = colorClockSprite[(int)etapa];
                gato.ColocarAlGato();
                if (dias == Dias.Viernes)
                    sueldo.sueldo += 100;
                break;

            case 2:
                etapa = EtapasDia.Night;
                colorlessGameClock.sprite = colorlessClockSprite[(int)etapa];
                colorGameClock.sprite = colorClockSprite[(int)etapa];
                gato.ColocarAlGato();
                break;

            case 3:
                etapa = EtapasDia.Morning;
                colorlessGameClock.sprite = colorlessClockSprite[(int)etapa];
                colorGameClock.sprite = colorClockSprite[(int)etapa];
                gato.ColocarAlGato();
                CambiarDia();
                break;
        }

    }

    private void CambiarDia()
    {
        int i = (int)dias;
        consumableManager.AppearIfOwn();
        interactuable.YaSeUso = false;
        switch (i)
        {
            case 0:
                dias = Dias.Martes;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;

            case 1:
                dias = Dias.Miercoles;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;

            case 2:
                dias = Dias.Jueves;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;

            case 3:
                dias = Dias.Viernes;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;

            case 4:
                dias = Dias.Sabado;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;

            case 5:
                dias = Dias.Domingo;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;

            case 6:
                dias = Dias.Lunes;
                colorlessGameCalendar.sprite = colorlessCalendarSprite[(int)dias];
                colorGameCalendar.sprite = colorCalendarSprite[(int)dias];
                break;
        }
    }
}
