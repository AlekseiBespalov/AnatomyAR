using System;
using Anatomy.Scripts.ARCoreScripts.ManipulationSystem;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Describe object which can be spawned and manipulated in Anatomy scenes
/// Set up all properties by Unity inspector
/// </summary>
[Serializable]
public class AnatomyObject : MonoBehaviour
{
    /// <summary>
    /// Store prefab for future actions (spawning, deleting, manipulating) in scene
    /// </summary>
    public GameObject Prefab { get => gameObject; }

    /// <summary>
    /// Store name for particular anatomy object if needed
    /// </summary>
    public string ObjectName { get => _objectName; }
    [SerializeField]
    private string _objectName;

    /// <summary>
    /// Description of anatomy object as Unity Text component
    /// </summary>
    public TextMeshProUGUI AnatomyObjectDescription { get => _anatomyObjectDescription; }
    [SerializeField]
    private TextMeshProUGUI _anatomyObjectDescription;

    /// <summary>
    /// Contains GameObject with individual UI for this object
    /// </summary>
    public GameObject IndividualUiObject { get => _individualUiObject; }
    [SerializeField]
    private GameObject _individualUiObject;

    /// <summary>
    /// Store instantiated individual ui in scene
    /// </summary>
    public GameObject InstantiatedUi { get; set; }

    /// <summary>
    /// True if needs to disable all controll interface except individual ui
    /// </summary>
    public bool OnlyIndividualUi { get=> _onlyIndividualUi; }
    [SerializeField]
    private bool _onlyIndividualUi;

    /// <summary>
    /// True if needs to disable all controll interface except individual ui
    /// </summary>
    public bool MultipleObjects { get=> _multipleObjects; }
    [SerializeField]
    private bool _multipleObjects;

    /// <summary>
    /// True if object can't be scaled in scene
    /// </summary>
    public bool Unscalable { get => _unscalable; }
    [SerializeField]
    private bool _unscalable;

    /// <summary>
    /// True if object can't be moved in scene
    /// </summary>
    public bool Unmovable { get => _unmovable; }
    [SerializeField]
    private bool _unmovable;

    private void Start() 
    {
        if (Unscalable)
            gameObject.transform.parent.GetComponentInChildren<ScaleManipulator>().enabled = false;
        else if (!Unscalable)
            gameObject.transform.parent.GetComponentInChildren<ScaleManipulator>().enabled = true;

        if (Unmovable)
            gameObject.transform.parent.GetComponentInChildren<TranslationManipulator>().enabled = false;
        else if (!Unmovable)
            gameObject.transform.parent.GetComponentInChildren<TranslationManipulator>().enabled = true;

        if (gameObject.GetComponentInChildren<TextMeshProUGUI>() != null)
            _anatomyObjectDescription = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        else
            Debug.LogError("Description not found in spawned anatomy object.");
    }
}
