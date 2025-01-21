using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private float estres;
    [SerializeField]
    private float felicidad;
    [SerializeField]
    private float amor;

    public float Estres { get => estres; set => estres = value; }
    public float Felicidad { get => felicidad; set => felicidad = value; }
    public float Amor { get => amor; set => amor = value; }
}
