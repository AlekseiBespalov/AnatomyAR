using System.Collections;
using System.Collections.Generic;
using Anatomy.Scripts.ARCoreScripts.ManipulationSystem;
using UnityEngine;

public class AnatomyObjectManager : MonoBehaviour
{
    public delegate void AnatomyObjectSpawnedHandler(AnatomyObject spawnedAnatomyObject);
    public event AnatomyObjectSpawnedHandler AnatomyObjectSpawned;

    public delegate void AnatomyObjectSelectedHandler(AnatomyObject selectedAnatomyObject);
    public event AnatomyObjectSelectedHandler AnatomyObjectSelected;

    public delegate void AnatomyObjectDeselectedHandler(AnatomyObject deselectedAnatomyObject);
    public event AnatomyObjectDeselectedHandler AnatomyObjectDeselected;

    public delegate void AnatomyObjectRemovedHandler(AnatomyObject removedAnatomyObject);
    public event AnatomyObjectRemovedHandler AnatomyObjectRemoved;

    public delegate void AnatomyObjectTranslatedHandler(AnatomyObject translatedAnatomyObject);
    public event AnatomyObjectTranslatedHandler AnatomyObjectTranslated;


    private ObjectManipulator objectManipulator;

    private void Start() 
    {
        ManipulationSystem.Instance.ObjectRemoved += OnObjectRemoved;
        objectManipulator = FindObjectOfType<ObjectManipulator>();

        if(objectManipulator != null)
            objectManipulator.ObjectSpawned += OnObjectSpawned;
        else
            Debug.LogWarning("Object manipulator not found in scene");
    }

    public void OnObjectSpawned(GameObject spawnedObject)
    {
        AnatomyObject anatomySpawnedObject = spawnedObject.GetComponentInChildren<AnatomyObject>();
        
        if(anatomySpawnedObject != null)
            AnatomyObjectSelected(anatomySpawnedObject);
    }

    public void OnObjectSelected(GameObject selectedObject)
    {
        AnatomyObject anatomySelectedObject = selectedObject.GetComponentInChildren<AnatomyObject>();
        
        if(anatomySelectedObject != null)
            AnatomyObjectSelected(anatomySelectedObject);
    }

    public void OnObjectDeselected(GameObject deselectedObject)
    {
        AnatomyObject anatomyDeselectedObject = deselectedObject.GetComponentInChildren<AnatomyObject>();
        
        if(anatomyDeselectedObject != null)
            AnatomyObjectDeselected(anatomyDeselectedObject);
    }

    public void OnObjectRemoved(GameObject removedObject)
    {
        AnatomyObject anatomyRemovedObject = removedObject.GetComponentInChildren<AnatomyObject>();
        
        if(anatomyRemovedObject != null)
            AnatomyObjectRemoved(anatomyRemovedObject);
    }
}
