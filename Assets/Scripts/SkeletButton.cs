using System.Collections;
using System.Collections.Generic;
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
    private float MaxSize;

    [SerializeField]
    private GameObject TextObject;
    [SerializeField]
    private float SmoothRotationValue;

    bool IsButtonPressed = false;

    bool ObjectIsScaledUp;
    bool ObjectIsScaledDown;

    float currentX;
    float currentY;
    float currentZ;


    private void Start() 
    {
        TextObject.SetActive(false);
    }

    private void FixedUpdate() 
    {
        currentX = transform.localScale.x;
        currentY = transform.localScale.y;
        currentZ = transform.localScale.z;

        ChangeScale();
    }

    private void RotateTowards()
    {
        float singleStep = SmoothRotationValue * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(RootObject.transform.forward, -Camera.main.transform.forward, singleStep, 0.0f);
        RootObject.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void ChangeScale()
    {
        if(currentX < MinSize && currentY < MinSize && currentZ < MinSize && IsButtonPressed)
        {
            transform.localScale = new Vector3(MinSize, MinSize, MinSize);
            ObjectIsScaledDown = true;
            ObjectIsScaledUp = false;
            IsButtonPressed = false;
            return;
        }

        if (currentX > MaxSize && currentY > MaxSize && currentZ > MaxSize && IsButtonPressed)
        {
            transform.localScale = new Vector3(MaxSize, MaxSize, MaxSize);
            ObjectIsScaledDown = false;
            ObjectIsScaledUp = true;
            IsButtonPressed = false;
            return;
        }

        if(IsButtonPressed && !ObjectIsScaledUp)
        {
            ScaleUp();
            RotateTowards();
            ObjectIsScaledDown = false;
        }
        if(!IsButtonPressed && !ObjectIsScaledDown)
        {
            ScaleDown();
            ObjectIsScaledUp = false;
        }
    }

    public void ScaleUp()
        {
            transform.localScale = new Vector3(currentX + DeltaSize, currentY + DeltaSize, currentZ + DeltaSize);
        }
    public void ScaleDown()
        {
            transform.localScale = new Vector3(currentX - DeltaSize, currentY - DeltaSize, currentZ - DeltaSize);
        }

    private void OnMouseDown() 
    {   
        IsButtonPressed = !IsButtonPressed;

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
