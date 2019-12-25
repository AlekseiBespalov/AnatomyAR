using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    [SerializeField]
    private GameObject TextObject;




    void Start()
    {
        
    }

    
    void Update()
    {
        
    HidText();
    }


   


    void HidText()
     {
         TextObject.SetActive(false);
     }

  


}
