using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOrMakeTransparent : MonoBehaviour
{

    [SerializeField]private SelectionManager _selectionManager;
    [SerializeField]private string _actionName;

    private void OnMouseDown()
    {
        _selectionManager = SelectionManager.Instance;
        if (_actionName == "Hide")
        {
            _selectionManager.ToggleHide();
        }
        
        if (_actionName == "Skip")
        {
            _selectionManager.ToggleTransparent();
        }
    }
}
