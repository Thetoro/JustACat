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

    private int points;
    private int progressPoints;
    private bool gameFinish;

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
        else
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
    }

    private void TailManager()
    {
        if (progressPoints < 3)
        {
            catSpriteRe.sprite = catSprite[0];
        }

        if (progressPoints >= 3 && progressPoints < 6)
        { 
            catSpriteRe.sprite = catSprite[1];
        }

        if (progressPoints >= 6 && progressPoints < 9)
        {
            catSpriteRe.sprite = catSprite[2];
        }

        if (progressPoints >= 9)
        {
            catSpriteRe.sprite = catSprite[3];
        }
        
        if(progressPoints >= 10)
            gameFinish = true;
    }

    private IEnumerator FinishGame()
    {

        winPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LivingRoom");
    }
}
