using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatToggle : MonoBehaviour
{
    public void TurnOffAllMeat()
    {
        List<GameObject> meats = new List<GameObject>();
        meats.AddRange(GameObject.FindGameObjectsWithTag("Meat"));
        List<MeshRenderer> meatMeshes = new List<MeshRenderer>();
        List<MeshCollider> meatColliders = new List<MeshCollider>();

        foreach(GameObject gameObject in meats)
        {
            meatColliders.AddRange(gameObject.GetComponentsInChildren<MeshCollider>());
            meatMeshes.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>());
        }

        foreach(MeshRenderer mesh in meatMeshes)
        {
            mesh.enabled = false;
        }

        foreach(MeshCollider meatColider in meatColliders)
        {
            meatColider.enabled = false;
        }
    }

    public void TurnOnAllMeat()
    {
        List<GameObject> meats = new List<GameObject>();
        meats.AddRange(GameObject.FindGameObjectsWithTag("Meat"));
        List<MeshRenderer> meatMesh = new List<MeshRenderer>();
        List<MeshCollider> meatColliders = new List<MeshCollider>();

        foreach(GameObject gameObject in meats)
        {
            meatColliders.AddRange(gameObject.GetComponentsInChildren<MeshCollider>());
            meatMesh.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>());
        }

        foreach(MeshRenderer mesh in meatMesh)
        {
            mesh.enabled = true;
        }

        foreach(MeshCollider meatColider in meatColliders)
        {
            meatColider.enabled = true;
        }
    }
}
