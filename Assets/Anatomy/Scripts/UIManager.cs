using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Manipulate standart UI which control objects and
/// can instantiate specified UI for each object.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Canvas component where individual UI of each object will be created.
    /// </summary>
    private Canvas MainCanvas;

    /// <summary>
    /// Standart UI for all anatomy objects across application.
    /// </summary>
    [SerializeField]
    private GameObject StandartUI;

    /// <summary>
    /// TextMeshPro component for displaying the name of selected anatomy objects
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI NamePanel;

    /// <summary>
    /// TextMeshPro component for displaying the description of selected anatomy objects
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI DescriptionPanel;

    /// <summary>
    /// Remove button separated from other interface elements.
    /// </summary>
    [SerializeField]
    private GameObject RemoveButton;

    /// <summary>
    /// Anatomy object manager to sign up for events with anatomy objects.
    /// </summary>
    private AnatomyObjectManager anatomyObjectManager;

    /// <summary>
    /// The Unity Start() method.
    /// </summary>
    void Start()
    {
        MainCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        anatomyObjectManager = GameObject.FindObjectOfType<AnatomyObjectManager>();
        
        if(anatomyObjectManager != null)
        {
            anatomyObjectManager.AnatomyObjectSpawned += OnAnatomyObjectSpawned;
            anatomyObjectManager.AnatomyObjectSelected += OnAnatomyObjectSelected;
            anatomyObjectManager.AnatomyObjectDeselected += OnObjectDeselected;
            anatomyObjectManager.AnatomyObjectRemoved += OnObjectRemoved;
        }
        else
        {
            Debug.LogError("Anatomy object manager not found in scene.");
        }

        if(StandartUI != null)
        {
            StandartUI.SetActive(false);
        }
        else
        {
            Debug.LogError("StandartUI not found in UIManager.");
        }

        if(StandartUI != null)
        {
            RemoveButton.SetActive(false);
        }
        else
        {
            Debug.LogError("RemoveButton not found in UIManager.");
        }
    }

    /// <summary>
    /// (NOT IMPLEMENTED) Changes interface when anatomy object spawned.
    /// FIXME: Implement interface reaction to new spawned object.
    /// </summary>
    /// <param name="anatomySpawnedObject">Spawned by ObjectManipulator anatomy object.</param>
    public void OnAnatomyObjectSpawned(AnatomyObject anatomySpawnedObject)
    {
        Debug.LogError("Anatomy spawned event is not implemented in UI manager.");
    }

    /// <summary>
    /// Changes interface when anatomy object selected.
    /// </summary>
    /// <param name="anatomySelectedObject">Selected by SelectingManipulator anatomy object.</param>
    public void OnAnatomyObjectSelected(AnatomyObject anatomySelectedObject)
    {
        RemoveButton.SetActive(true);
        StandartUI.SetActive(true);

        SetNameAndDescriptionOfAnatomyObject(anatomySelectedObject);

        var individualUiObject = anatomySelectedObject.IndividualUiObject;
        var instantiatedUi = anatomySelectedObject.InstantiatedUi;
        var onlyIndividualUi = anatomySelectedObject.OnlyIndividualUi;

        if(individualUiObject != null && instantiatedUi == null)
        {
            GameObject tempInstantiatedUi = Instantiate(anatomySelectedObject.IndividualUiObject);
            tempInstantiatedUi.transform.SetParent(MainCanvas.transform, false);
            tempInstantiatedUi.SetActive(true);
            anatomySelectedObject.InstantiatedUi = tempInstantiatedUi;
        }
        else if(instantiatedUi != null && onlyIndividualUi)
        {
            anatomySelectedObject.InstantiatedUi.SetActive(true);
            StandartUI.SetActive(false);
        }    
        else if(instantiatedUi == null && !onlyIndividualUi)
        {
            StandartUI.SetActive(true);
        }
        else if(instantiatedUi != null && !onlyIndividualUi)
        {
            anatomySelectedObject.InstantiatedUi.SetActive(true);
            StandartUI.SetActive(true);
        }
        else if(instantiatedUi == null && onlyIndividualUi)
        {
            StandartUI.SetActive(false);
        }
    }

    /// <summary>
    /// Changes interface when anatomy object deselected.
    /// FIXME: When object deselected deactivate remove button (but it's doesn't work as supposed).
    /// </summary>
    /// <param name="anatomyDeselectedObject">Deselected by SelectingManipulator anatomy object.</param>
   
    public void OnObjectDeselected(AnatomyObject anatomyDeselectedObject)
    {
        RemoveButton.SetActive(false);
        StandartUI.SetActive(false);

        if(anatomyDeselectedObject.InstantiatedUi == null)
        { 
            StandartUI.SetActive(false);
        }
        else
        {
            anatomyDeselectedObject.InstantiatedUi.SetActive(false);
            StandartUI.SetActive(false);
        }
    }

    /// <summary>
    /// Changes interface when anatomy object removed.
    /// </summary>
    /// <param name="anatomyRemovedObject">Removed by ManipulationSystem anatomy object.</param>
    public void OnObjectRemoved(AnatomyObject anatomyRemovedObject)
    {
        RemoveButton.SetActive(false);
        
        if(anatomyRemovedObject.InstantiatedUi == null)
        {
            StandartUI.SetActive(false);
        }
        else
        {
            anatomyRemovedObject.InstantiatedUi.SetActive(false);
            Destroy(anatomyRemovedObject.InstantiatedUi);
            anatomyRemovedObject.InstantiatedUi = null;
            StandartUI.SetActive(false);
        }
    }

    public void SetNameAndDescriptionOfAnatomyObject(AnatomyObject anatomyObject)
    {
        NamePanel.SetText(anatomyObject.ObjectName);
        DescriptionPanel.SetText(anatomyObject.AnatomyObjectDescription.text);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
