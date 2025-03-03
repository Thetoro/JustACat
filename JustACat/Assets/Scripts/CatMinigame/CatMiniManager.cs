using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMiniManager : MonoBehaviour
{
    [SerializeField]
    private DeteccionMano detecciones;
    [SerializeField]
    private SpriteRenderer catSpriteRe;
    [SerializeField]
    private Sprite[] catSprite;
    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private AudioSource ronroneo;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;

    private int points;
    private int progressPoints;
    private bool gameFinish;
    private bool once;

    private void Start()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFinish)
        {
            PointManager();
            TailManager();
            Debug.Log(points);
            Debug.Log(progressPoints);
        }
        else if (!once) 
        {
            StartCoroutine("FinishGame");
        }
        
    }

    private void PointManager()
    {
        if (detecciones.CurrentCollider.gameObject.tag == "Cabeza" && detecciones.IsMoving)
            points += 2;

        if (detecciones.CurrentCollider.gameObject.tag == "Lomo" && detecciones.IsMoving)
            points += 5;

        if (detecciones.CurrentCollider.gameObject.tag == "Cola" && detecciones.IsMoving)
            points += 8;

        if (points > 800)
        { 
            progressPoints += 1;
            points = 0;
        }

        if (progressPoints == 1 && !once)
        { 
            ronroneo.Play();
            once = true;
        }
        
    }

    private void TailManager()
    {
        if (progressPoints < 3)
        {
            catSpriteRe.sprite = catSprite[0];
            if (progressPoints == 2)
                once = false;
        }

        if (progressPoints >= 3 && progressPoints < 6)
        { 
            catSpriteRe.sprite = catSprite[1];
            
            if (progressPoints == 3 && !once)
            {
                audioSource.PlayOneShot(audioClip[1]);
                once = true;
            }
            if (progressPoints == 4)
                once = false;
        }

        if (progressPoints >= 6 && progressPoints < 9)
        {
            catSpriteRe.sprite = catSprite[2];
            
            if (progressPoints == 6 && !once)
            {
                audioSource.PlayOneShot(audioClip[2]);
                once = true;
            }
            if (progressPoints == 7)
                once = false;
        }

        if (progressPoints >= 9)
        {
            catSpriteRe.sprite = catSprite[3];
            
            if (progressPoints == 9 && !once)
            {
                audioSource.PlayOneShot(audioClip[3]);
                once = true;
            }
            
        }

        if (progressPoints >= 10)
        {
            gameFinish = true;
            audioSource.Stop();
            once = false;
        }
            
    }

    private IEnumerator FinishGame()
    {

        winPanel.SetActive(true);
        audioSource.PlayOneShot(audioClip[1]);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LivingRoom");
    }
}
