using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatToggle : MonoBehaviour
{
    public void TurnOffAllMeat()
    {
        List<GameObject> meats = new List<GameObject>();
        meats.AddRange(GameObject.FindGameObjectsWithTag("Meat"));
        List<MeshRenderer> meatMesh = new List<MeshRenderer>();
        foreach(GameObject gameObject in meats)
        {
            meatMesh.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>());
        }

        foreach(MeshRenderer mesh in meatMesh)
        {
            mesh.enabled = false;
        }
    }

    public void TurnOnAllMeat()
    {
        List<GameObject> meats = new List<GameObject>();
        meats.AddRange(GameObject.FindGameObjectsWithTag("Meat"));
        List<MeshRenderer> meatMesh = new List<MeshRenderer>();
        foreach(GameObject gameObject in meats)
        {
            meatMesh.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>());
        }

        foreach(MeshRenderer mesh in meatMesh)
        {
            mesh.enabled = true;
        }
    }
}
