using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tiempo Guardado")]
public class TiempoSO : ScriptableObject
{
    public enum EtapasDia
    {
        Morning,
        Noon,
        Afternoon,
        Night
    }

    public enum Dias
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }

    public EtapasDia etapaGuardada;
    public Dias diaGuardado;
    public Color lightColor;
    public float wight;
    public float intensity;
}
