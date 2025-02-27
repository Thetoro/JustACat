using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogos : MonoBehaviour
{
    //Llega a la casa y suena el telefono
    [SerializeField, TextArea(1, 5)]
    private string[] parte1;
    //Llamada con su madre
    [SerializeField, TextArea(1, 5)]
    private string[] parte2;
    //Tocan a la puerta
    [SerializeField, TextArea(1, 5)]
    private string[] parte3;
    //Es solo un gato
    [SerializeField, TextArea(1, 5)]
    private string[] parte4;

    [SerializeField]
    private float tiempoEntreLetras;
    [SerializeField]
    private GameObject cuadroDialogo;
    [SerializeField]
    private TextMeshProUGUI textoDialogo;
    [SerializeField]
    private GatoSO gato;
    [SerializeField]
    private GameObject nombreInput;
    [SerializeField]
    private InputActionAsset inputActions;

    private bool hablando;
    private int index = -1;
    private bool parteTerminada;

    public bool ParteTerminada { get => parteTerminada; set => parteTerminada = value; }

    public void MostrarDialogos(int i)
    {
        string[] parteX = null;
        switch (i)
        {
            case 1:
                parteX = parte1;
                break;

            case 2:
                parteX = parte2;
                break;

            case 3:
                parteX = parte3;
                break;

            case 4:
                parteX = parte4;
                break;
        }


        parteTerminada = false;
        if (!hablando)
        { 
            Siguiente(parteX);
            cuadroDialogo.SetActive(true);
            if (parteX == parte4 && index == 4)
            {
                inputActions.Disable();
                nombreInput.SetActive(true);
            }
        }
        else
            completaDialogo(parteX);
    }

    private void completaDialogo(string[] dialogos)
    {
        StopAllCoroutines();
        textoDialogo.text = dialogos[index];
        hablando = false;
    }

    private void Siguiente(string[] dialogos)
    { 
        index++;
        if (index >= dialogos.Length)
            Terminar();
        else
            StartCoroutine(EscreibirDialogo(dialogos));
    }

    private void Terminar()
    {
        Debug.Log("Hola");
        cuadroDialogo.SetActive(false);
        hablando = false;
        textoDialogo.text = "";
        parteTerminada = true;
        index = -1;
    }

    private IEnumerator EscreibirDialogo(string[] dialogos)
    {
        hablando = true;
        textoDialogo.text = "";
        char[] caracteresDialogo = dialogos[index].ToCharArray();
        foreach (char caracter in caracteresDialogo)
        {
            textoDialogo.text += caracter;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
        hablando = false;
    }

    public void GatoNombre(string nombre)
    {
        if (nombre != "")
        {
            gato.gatoNombre = nombre;
            nombreInput.SetActive(false);
            inputActions.Enable();
        }
    }

    
}
