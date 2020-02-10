using UnityEngine;

/// <summary>
/// Manipulate standart UI which control objects and
/// can instantiate specified UI for each object
/// </summary>
public class UIManager : MonoBehaviour
{
    private Canvas MainCanvas;

    [SerializeField]
    private GameObject StandartUI;
    [SerializeField]
    private GameObject RemoveButton;

    private AnatomyObjectManager anatomyObjectManager;

    void Start()
    {
        MainCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        anatomyObjectManager = GameObject.FindObjectOfType<AnatomyObjectManager>();
        
        if(anatomyObjectManager != null)
        {
            anatomyObjectManager.AnatomyObjectSelected += OnAnatomyObjectSelected;
            anatomyObjectManager.AnatomyObjectDeselected += OnObjectDeselected;
            anatomyObjectManager.AnatomyObjectRemoved += OnObjectRemoved;
        }
        else
            Debug.LogWarning("Anatomy object manager not found in scene");

        StandartUI.SetActive(false);
        RemoveButton.SetActive(false);
    }

    public void OnAnatomyObjectSelected(AnatomyObject anatomySelectedObject)
    {
        RemoveButton.SetActive(true);

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
            StandartUI.SetActive(true);

        else if(instantiatedUi != null && !onlyIndividualUi)
        {
            anatomySelectedObject.InstantiatedUi.SetActive(true);
            StandartUI.SetActive(true);
        }

        else if(instantiatedUi == null && onlyIndividualUi)
            StandartUI.SetActive(false);
    }

    //FIXME: When object deselected deactivate remove button (but it's doesn't work as suppose)
    public void OnObjectDeselected(AnatomyObject anatomyDeselectedObject)
    {
        // RemoveButton.SetActive(false)

        if(anatomyDeselectedObject.InstantiatedUi == null)
            StandartUI.SetActive(false);

        else
        {
            anatomyDeselectedObject.InstantiatedUi.SetActive(false);
            StandartUI.SetActive(false);
        }
    }

    public void OnObjectRemoved(AnatomyObject anatomyRemovedObject)
    {
        RemoveButton.SetActive(false);
        
        if(anatomyRemovedObject.InstantiatedUi == null)
            StandartUI.SetActive(false);

        else
        {
            anatomyRemovedObject.InstantiatedUi.SetActive(false);
            Destroy(anatomyRemovedObject.InstantiatedUi);
            anatomyRemovedObject.InstantiatedUi = null;
            StandartUI.SetActive(false);
        }
    }
}
