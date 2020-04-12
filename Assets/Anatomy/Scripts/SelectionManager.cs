using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private static SelectionManager s_Instance = null;

    [SerializeField]private string selectableTag = "Selectable";
    [SerializeField]private GameObject _panelObject;
    [SerializeField]private float _highlightIntensity = -4f;
    [SerializeField]Color _highlightColor = new Color(0, 191, 255, 255);

    [SerializeField]private Material _transparentMaterial;

    private Material _defaultMaterial;

    private Transform _selectedObject;

    public static SelectionManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var selectionManagers = FindObjectsOfType<SelectionManager>();
                if (selectionManagers.Length > 0)
                {
                    s_Instance = selectionManagers[0];
                }
                else
                {
                    Debug.LogError("No instance of SelectionManager exists in the scene.");
                }
            }
    
            return s_Instance;
        }
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            var ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    var selection = hit.transform;
                    
                    if (selection.CompareTag(selectableTag) && _selectedObject != selection.transform)
                    {
                        if (_defaultMaterial != null && _selectedObject != null && _selectedObject.GetComponent<Renderer>().material.color != _transparentMaterial.color)
                        {
                            _selectedObject.GetComponent<Renderer>().material = _defaultMaterial;
                        }
                    
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            if (selectionRenderer.material.color != _transparentMaterial.color)
                            {
                                _defaultMaterial = selectionRenderer.material;
                            }
                    
                            selectionRenderer.material = GetHighlightMaterial(selectionRenderer.material);
                            PrintName(hit.transform.gameObject);
                        }
                    
                        _selectedObject = selection;

                        if(_panelObject != null)
                        {
                            _panelObject.SetActive(true);
                            var referencePosition = _selectedObject.GetChild(0).position;
                            _panelObject.transform.position = referencePosition;
                        }
                    }
                }
            }

            else
            {
                if (_selectedObject != null)
                {
                    if (_panelObject != null)
                    {
                        _panelObject.SetActive(false);
                    }

                    var selectionRenderer = _selectedObject.GetComponent<Renderer>();
                    if (selectionRenderer.material.color != _transparentMaterial.color)
                        selectionRenderer.material = _defaultMaterial;
                    _selectedObject = null;
                }
            }
        }
    }
    
    private Material GetHighlightMaterial(Material defaultMaterial)
    {
        var material = Instantiate(defaultMaterial);

        material.color = _highlightColor;
        material.EnableKeyword("_EMISSION");

        float adjustedIntensity = _highlightIntensity - (0.4169f);
        var color = _highlightColor * Mathf.Pow(2.0f, adjustedIntensity);

        material.SetColor("_EmissionColor", color);

        return material;
    }

    public void ToggleTransparent()
    {
        if (_selectedObject != null)
        {
            var material = _selectedObject.GetComponent<Renderer>().material;
            if (material.color == _transparentMaterial.color)
            {
                _selectedObject.GetComponent<Renderer>().material = GetHighlightMaterial(_defaultMaterial);
            }
            else
            {
                _selectedObject.GetComponent<Renderer>().material = _transparentMaterial;
            }
        }
    }

    public void ToggleHide()
    {
        if (_selectedObject != null)
        {
            _selectedObject.GetComponent<MeshRenderer>().enabled = !_selectedObject.GetComponent<MeshRenderer>().enabled;
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }
}
