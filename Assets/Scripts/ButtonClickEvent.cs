using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    }

    public void Click()
    {
        TextToHide.SetActive(!TextToHide.active);
    }
}
