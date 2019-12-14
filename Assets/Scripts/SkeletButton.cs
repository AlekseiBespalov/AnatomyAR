using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkeletButton : MonoBehaviour
{
    [SerializeField]
    private GameObject RootObject;

    [SerializeField]
    private float DeltaSize;
    [SerializeField]
    private float MinSize;

    [SerializeField]
    private float MaxSize;

    [SerializeField]
    private GameObject TextObject;
    [SerializeField]
    private float SmoothRotationValue;
    [SerializeField]
    private float TimeToRotate;

    bool IsButtonPressed = false;

    bool ObjectIsScaledUp;
    bool ObjectIsScaledDown;
    bool ObjectIsScalingUp;

    float CurrentX;
    float CurrentY;
    float CurrentZ;

    private void Start() 
    {
        TextObject.SetActive(false);
    }

    private void FixedUpdate() 
    {
        CurrentX = transform.localScale.x;
        CurrentY = transform.localScale.y;
        CurrentZ = transform.localScale.z;

        ChangeScale();
        RotateTowards();
    }

    private void RotateTowards()
    {
        if(ObjectIsScalingUp)
        {
            float singleStep = SmoothRotationValue * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(RootObject.transform.forward, -Camera.main.transform.forward, singleStep, 0.0f);
            RootObject.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void ChangeScale()
    {
        if(CurrentX < MinSize && CurrentY < MinSize && CurrentZ < MinSize)
        {
            transform.localScale = new Vector3(MinSize, MinSize, MinSize);
            ObjectIsScaledDown = true;
            ObjectIsScaledUp = false;
            ObjectIsScalingUp = false;
        }

        if (CurrentX > MaxSize && CurrentY > MaxSize && CurrentZ > MaxSize)
        {
            transform.localScale = new Vector3(MaxSize, MaxSize, MaxSize);
            ObjectIsScaledDown = false;
            ObjectIsScaledUp = true;
        }

        if(IsButtonPressed && !ObjectIsScaledUp)
        {
            ScaleUp();
            ObjectIsScaledDown = false;
            ObjectIsScalingUp = true;
        }
        if(!IsButtonPressed && !ObjectIsScaledDown)
        {
            ScaleDown();
            ObjectIsScaledUp = false;
        }
    }

    public void ScaleUp()
    {
        transform.localScale = new Vector3(CurrentX + DeltaSize, CurrentY + DeltaSize, CurrentZ + DeltaSize);
    }
    public void ScaleDown()
    {
            transform.localScale = new Vector3(CurrentX - DeltaSize, CurrentY - DeltaSize, CurrentZ - DeltaSize);
    }

    private void OnMouseDown() 
    {   
        IsButtonPressed = !IsButtonPressed;

        // //comment for Android touch input
        // Touch touch;
        // touch = Input.GetTouch(0);

        // int fingerId = touch.fingerId;

        // if(Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(fingerId))
        //     IsButtonPressed = !IsButtonPressed;
    }
}
