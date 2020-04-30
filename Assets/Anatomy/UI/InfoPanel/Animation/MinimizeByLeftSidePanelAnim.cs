using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimizeByLeftSidePanelAnim : MonoBehaviour
{
    private bool isOpen = true;
    private Animator panelAnimator;

    private void Start()
    {
        panelAnimator = gameObject.GetComponent<Animator>();
    }

    public void Animate()
    {
        if (isOpen == true)
        {
            panelAnimator.Play("In");
            isOpen = false;
        }

        else
        {
            panelAnimator.Play("Out");
            isOpen = true;
        }
    }
}
