using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    private Transform amorGato;
    [SerializeField]
    private StatsSO stats;
    
    private float circleSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ActualizarAmorGato()
    {
        circleSize = stats.amorGato * 0.01f;
        amorGato.transform.localScale = new Vector3(circleSize,circleSize,1);
    }
}
