using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLivRoom : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BGM());
    }

    private IEnumerator BGM()
    {
        
        while (true)
        {
            int index = Random.Range(0, audioClip.Length);
            audioSource.PlayOneShot(audioClip[index]);
            yield return new WaitForSeconds(audioClip[index].length);
        }

    }
}
