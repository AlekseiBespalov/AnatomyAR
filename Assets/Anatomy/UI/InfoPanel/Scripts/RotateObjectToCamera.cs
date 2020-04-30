using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectToCamera : MonoBehaviour
{
    public GameObject ObjectForRotation;

    public float DistanceToOff;

    private float DistanceToText;

    private void DistanceToTextUpdate()
    {
        var Dist = Vector3.Distance(Camera.main.transform.position, transform.position);
        DistanceToText = Dist;
    }
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(Vector3.up - new Vector3(0, 180, 0));
        DistanceToTextUpdate();
        CheckDistanceToText();
    }
    private void CheckDistanceToText()
    {
        if(DistanceToText <= DistanceToOff)
        {
            ObjectForRotation.SetActive(false);
        }
        else if(DistanceToText > DistanceToOff)
        {
            ObjectForRotation.SetActive(true);
        }
    }
}
