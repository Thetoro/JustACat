using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private DialogosEvento1 dialogos;
    [SerializeField]
    private Animator animEstres;

    [SerializeField]
    private Volume volumen;
    [SerializeField]
    private Light2D foco;
    [SerializeField]
    private Light2D globalLight;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;
    [SerializeField]
    private AudioSource bgm;

    private bool parte1 = true;
    private bool parte2;
    private bool parte3;

    private bool once;

    private int currentPart = 1;

    // Start is called before the first frame update
    void Start()
    {
        //dialogos.MostrarDialogos(currentPart);
        animEstres.SetTrigger("Estres6");
        audioSource.PlayOneShot(audioClip[0]);
        globalLight.color = new Color(1f, 1f, 1f, 1f);
        volumen.weight = 0.7f;
        foco.intensity = 5.5f;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        if (parte1)
        {
            if (!once)
            {
                AvanzarParte1();
                once = true;
            }
            else
            {
                AvanzarParte1();
            }
            
        }

        if (parte2)
        {
            audioSource.Stop();
            if (!once)
            {
                volumen.weight = 1.0f;
                foco.intensity = 0;
                globalLight.intensity = 0;
                audioSource.PlayOneShot(audioClip[1]);
                AvanzarParte2();
                StartCoroutine(Parte2());
            }
            else 
                AvanzarParte2();
           
        }

        if (parte3)
        {
            if (!once)
            {
                StartCoroutine(Parte3());   
            }
            else
                AvanzarParte3();
        }

    }

    private void AvanzarParte1()
    {
        dialogos.MostrarDialogos(currentPart);
        if (dialogos.ParteTerminada)
        {
            currentPart++;
            parte1 = false;
            parte2 = true;
            once = false;
        }
    }

    private void AvanzarParte2()
    {
        dialogos.MostrarDialogos(currentPart);
        if (dialogos.ParteTerminada)
        {
            currentPart++;
            parte2 = false;
            parte3 = true;
            once = false;
        }
    }

    private void AvanzarParte3()
    {
        dialogos.MostrarDialogos(currentPart);
        if (dialogos.ParteTerminada)
        {
            currentPart++;
            parte3 = false;
            once = false;
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("LivingRoom");
    }

    IEnumerator Parte2()
    {
        once = true;
        audioSource.PlayOneShot(audioClip[2]);
        yield return new WaitForSeconds(audioClip[2].length);
        AvanzarParte2();
    }

    IEnumerator Parte3()
    {
        once = true;
        audioSource.PlayOneShot(audioClip[3]);
        yield return new WaitForSeconds(audioClip[3].length);
        audioSource.clip = audioClip[4];
        audioSource.loop = true;
        audioSource.Play();
        bgm.Stop();
        AvanzarParte3();
    }
}
