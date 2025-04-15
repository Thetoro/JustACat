using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Guardar Basura")]
public class BasuraSO : ScriptableObject
{
    public List<Vector3> positionTrashBeer = new List<Vector3>();
    public List<Vector3> positionTrashCigarette = new List<Vector3>();

    //UnityEditor.EditorUtility.SetDirty(this);
}
