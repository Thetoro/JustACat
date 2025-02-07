using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    // Start is called before the first frame update
    void Start()
    {
        ColocarAlGato();
    }

    public void ColocarAlGato()
    {
        int i = 0;

        i = Random.Range(0, positions.Length);

        this.transform.position = positions[i].position;
    }
}
