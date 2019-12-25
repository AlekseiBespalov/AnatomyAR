using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonClickEvent : MonoBehaviour
{
    [SerializeField] UnityEvent Event;
    [SerializeField] GameObject TextToHide;
    
    private void Start() 
    {
        TextToHide.SetActive(false);    
    }

    private void OnMouseDown()
    {
        Event.Invoke();
        
        // Touch touch;
        // touch = Input.GetTouch(0);

        // int fingerId = touch.fingerId;

        // if(Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(fingerId))
        //     Event.Invoke();
    }

    public void Click()
    {
        TextToHide.SetActive(!TextToHide.active);
    }
}
