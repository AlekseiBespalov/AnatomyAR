using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkeletButton : MonoBehaviour
{
    [SerializeField]
    private float DeltaSize;

    [SerializeField]
    private GameObject TextObject;
    
    [SerializeField]
    private float SmoothRotationValue;

    [SerializeField]
    private float SmoothScalingValue;

    bool IsSwitched = false;
    bool IsSized = false;

    private void Start() 
    {
        TextObject.SetActive(false);
    }

    private void Update() 
    {
        if(IsSwitched)
        {
            RotateTowards();
            ChangeSize();
        }
    }

    private void RotateTowards()
    {
        float singleStep = SmoothRotationValue * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.parent.forward, -Camera.main.transform.forward, singleStep, 0.0f);
        transform.parent.rotation = Quaternion.LookRotation(newDirection);
    }

    private void ChangeSize()
    {
        float singleStep = SmoothScalingValue * Time.deltaTime;
        transform.localScale += new Vector3(DeltaSize, DeltaSize, DeltaSize) * singleStep;
    }

    private void OnMouseDown() 
    {   
        if(!IsSwitched)
        {
            transform.localScale += new Vector3(DeltaSize, DeltaSize, DeltaSize);
            TextObject.SetActive(true);
            IsSwitched = true;
            return;
        }
        
        if(IsSwitched)
        {
            transform.localScale -= new Vector3(DeltaSize, DeltaSize, DeltaSize);
            TextObject.SetActive(false);
            IsSwitched = false;
            return;
        }

        // comment for Android touch input
        // Touch touch;
        // touch = Input.GetTouch(0);

        // int fingerId = touch.fingerId;

        // if(Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(fingerId) && !IsSwitched)
        // {
        //     transform.localScale = new Vector3(BaseLocalScale.x + DeltaSize, BaseLocalScale.y + DeltaSize, BaseLocalScale.z + DeltaSize);
        //     TextObject.SetActive(true);
        //     IsSwitched = true;
        //     return;
        // }
        
        // if(Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(fingerId) && IsSwitched)
        // {
        //     transform.localScale = new Vector3(BaseLocalScale.x - DeltaSize, BaseLocalScale.y - DeltaSize, BaseLocalScale.z - DeltaSize);
        //     TextObject.SetActive(false);
        //     IsSwitched = false;
        //     return;
        // }
    }
}
