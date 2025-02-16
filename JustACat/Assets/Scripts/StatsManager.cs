using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    private Transform amorGato;
    [SerializeField]
    private SpriteRenderer spriteRe_Animo;
    [SerializeField]
    private Sprite[] animo;
    [SerializeField]
    private Animator estres;
    [SerializeField]
    private StatsSO stats;
    
    private float circleSize;
    private bool actualizarGato;
    private bool actualizarAnimo;
    private bool actualizarEstres;

    public bool ActualizarGato { get => actualizarGato; set => actualizarGato = value; }
    public bool ActualizarAnimo { get => actualizarAnimo; set => actualizarAnimo = value; }
    public bool ActualizarEstres { get => actualizarEstres; set => actualizarEstres = value; }

    // Start is called before the first frame update
    void Start()
    {
        ActualizarAmorGato();
        ActualizarEstresAnim();
        ActualizarAnimoSprite();
    }

    private void Update()
    {
        if (actualizarGato)
            ActualizarAmorGato();
        if(actualizarAnimo)
            ActualizarAnimoSprite();
        if(actualizarEstres)
            ActualizarEstresAnim();
        
        
        if(stats.estres < 0)
            stats.estres = 0;
        if(stats.animo < 0)
            stats.animo = 0;
        if(stats.amorGato < 0)
            stats.amorGato = 0;
        
        if(stats.estres > 100)
            stats.estres = 100;
        if(stats.animo > 100)
            stats.animo = 100;
    }

    private void ActualizarAmorGato()
    {
        circleSize = stats.amorGato * 0.01f;
        amorGato.transform.localScale = new Vector3(circleSize,circleSize,1);
        actualizarGato = false;
    }

    private void ActualizarAnimoSprite()
    {
        if (stats.animo < 40)
        {
            spriteRe_Animo.sprite = animo[0];
        }
        
        if (stats.animo >= 40 && stats.animo < 80)
        {
            spriteRe_Animo.sprite = animo[1];
        }

        if (stats.animo >= 80)
        {
            spriteRe_Animo.sprite = animo[2];
        }

        actualizarAnimo = false;
    }

    private void ActualizarEstresAnim()
    {
        if (stats.estres < 10)
            estres.SetTrigger("Estres1");
        
        if (stats.estres >= 10 && stats.estres < 30)
            estres.SetTrigger("Estres2");

        if (stats.estres >= 30 && stats.estres < 50)
            estres.SetTrigger("Estres3");

        if (stats.estres >= 50 && stats.estres < 70)
            estres.SetTrigger("Estres4");

        if (stats.estres >= 70 && stats.estres < 90)
            estres.SetTrigger("Estres5");

        if (stats.estres >= 90)
            estres.SetTrigger("Estres6");

        actualizarEstres = false;
    }
}
