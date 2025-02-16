using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrashManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trashCigarettes;
    [SerializeField]
    private GameObject trashBeer;
    [SerializeField]
    private BasuraSO guardarBasura;

    private static int trashCount;

    private void Start()
    {
        if (guardarBasura.positionTrashCigarette.Count > 0)
        {
            for (int i = 0; i < guardarBasura.positionTrashCigarette.Count; i++)
            {
                Instantiate(trashCigarettes, guardarBasura.positionTrashCigarette[i], Quaternion.identity);
            }
        }

        if (guardarBasura.positionTrashBeer.Count > 0)
        {
            for (int i = 0; i < guardarBasura.positionTrashBeer.Count; i++)
            {
                Instantiate(trashBeer, guardarBasura.positionTrashBeer[i], trashBeer.transform.rotation);
            }
        }
    }

    public void SpawnTrashCigarette()
    {
        float x = Random.Range(-4.25f,4.54f);
        float y = Random.Range(-2.57f, -4.37f);
        Vector3 position = new Vector3(x,y,0);
        guardarBasura.positionTrashCigarette.Add(position);
        Instantiate(trashCigarettes, position, Quaternion.identity);
        trashCount++;
    }

    public void SpawnTrashBeer() 
    {
        float x = Random.Range(-4.25f, 4.54f);
        float y = Random.Range(-2.57f, -4.37f);
        Vector3 position = new Vector3(x, y, 0);
        guardarBasura.positionTrashBeer.Add(position);
        Instantiate(trashBeer, position, trashBeer.transform.rotation);
        trashCount++;
    }

    public void DestroyTrash(GameObject basura)
    { 
        Destroy(basura);
        if (basura.name == "TrashCigarette(Clone)")
            guardarBasura.positionTrashCigarette.Remove(basura.transform.position);
        if(basura.name == "TrashBeer(Clone)")
            guardarBasura.positionTrashBeer.Remove(basura.transform.position);
        trashCount--;
    }

    public bool IsClean()
    { return trashCount == 0; }
}
