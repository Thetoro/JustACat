using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;


    // Start is called before the first frame update
    void Start()
    {
        ColocarAlGato();
    }

    private void OnEnable()
    {
        StartCoroutine(CatSounds());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void ColocarAlGato()
    {
        int i = 0;

        i = Random.Range(0, positions.Length);

        this.transform.position = positions[i].position;
    }

    private IEnumerator CatSounds()
    {
        while (true)
        {
            int randIndex = Random.Range(0, audioClip.Length);
            audioSource.PlayOneShot(audioClip[randIndex]);
            yield return new WaitForSeconds(10);
        }
    }
}
