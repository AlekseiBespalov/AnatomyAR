using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAt : MonoBehaviour
{
    [SerializeField]
    private GameObject TextForLookAt;

    [SerializeField]
    private float DistanceToEnableText;
    
    private float CurrentDistanceToText;

    private void Update() 
    {
        TextForLookAt.transform.LookAt(Camera.main.transform);
        TextForLookAt.transform.Rotate(Vector3.up - new Vector3(0, 180, 0));
        DistanceToTextUpdate();
        CheckDistanceToText();
    }

    private void DistanceToTextUpdate()
    {
        CurrentDistanceToText = Vector3.Distance(Camera.main.transform.position, transform.position);
    }

    private void CheckDistanceToText()
    {
        if(CurrentDistanceToText <= DistanceToEnableText)
            TextForLookAt.SetActive(true);
        else
            TextForLookAt.SetActive(false);
    }
}
