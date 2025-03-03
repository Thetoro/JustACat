using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EventoInicio : MonoBehaviour
{
    [SerializeField]
    private Dialogos dialogos;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite clockSprite;
    [SerializeField]
    private Light2D foco;
    [SerializeField]
    private Volume volumen;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;

    private bool parte1 = true;
    private bool parte2;
    private bool parte3;
    private bool parte4;

    private bool once;

    private int currentPart = 1;
    private int countDialogs;

    // Start is called before the first frame update
    void Start()
    {
        //dialogos.MostrarDialogos(currentPart);
        volumen.weight = 0.7f;
        foco.intensity = 5.5f;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        if (parte1)
        {
            countDialogs++;
            if (!once)
            {
                AvanzarParte1();
                audioSource.PlayOneShot(audioClip[0]);
                once = true;
            }
            else
            {
                AvanzarParte1();
            }
            if (countDialogs == 4)
                audioSource.Stop();
        }

        if (parte2)
        {
            audioSource.Stop();
            if (!once)
            {
                StartCoroutine(Fades());
                Invoke("AvanzarParte2", 1);
                audioSource.PlayOneShot(audioClip[1]);
                spriteRenderer.sprite = clockSprite;
                volumen.weight = 1f;
                foco.intensity = 40f;
            }
            else
                AvanzarParte2();
        }

        if (parte3)
        {
            audioSource.Stop();
            if (!once)
            {
                StartCoroutine(Fades());
                Invoke("AvanzarParte3", 1);
                audioSource.PlayOneShot(audioClip[2]);
            }
            else
                AvanzarParte3();
        }

        if (parte4)
        {
       
            if (!once)
            {
                StartCoroutine(Fades());
                Invoke("AvanzarParte4", 1);
                StartCoroutine(CatSound());
            }
            else
                AvanzarParte4();
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
            parte4 = true;
            once = false;
        }
    }

    private void AvanzarParte4()
    {
        dialogos.MostrarDialogos(currentPart);
        if (dialogos.ParteTerminada)
        {
            parte4 = false;
            once = false;
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator Fades()
    {
        once = true;
        anim.SetTrigger("FadeIn");
        anim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(2);
    }

    IEnumerator ChangeScene()
    {
        anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LivingRoom");
    }

    IEnumerator CatSound()
    {
        audioSource.PlayOneShot(audioClip[3]);
        yield return new WaitForSeconds(audioClip[3].length);
        audioSource.PlayOneShot(audioClip[4]);
    }
}
