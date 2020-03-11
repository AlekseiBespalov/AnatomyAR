using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// AnatomyObjectManager allows developers to get events (select, deselect,
/// removed, spawned) for particular object which is manipulated by manipulation system.
/// 
/// The class alerts about events with GameObjects in ManipulationSystem(ARCore) and
/// send AnatomyObject with parameters for each object.
/// </summary>
public class AnatomyObjectManager : MonoBehaviour
{
    private static AnatomyObjectManager s_Instance = null;

    public delegate void AnatomyObjectSpawnedHandler(AnatomyObject spawnedAnatomyObject);
    public event AnatomyObjectSpawnedHandler AnatomyObjectSpawned;

    public delegate void AnatomyObjectSelectedHandler(AnatomyObject selectedAnatomyObject);
    public event AnatomyObjectSelectedHandler AnatomyObjectSelected;

    public delegate void AnatomyObjectDeselectedHandler(AnatomyObject deselectedAnatomyObject);
    public event AnatomyObjectDeselectedHandler AnatomyObjectDeselected;

    public delegate void AnatomyObjectRemovedHandler(AnatomyObject removedAnatomyObject);
    public event AnatomyObjectRemovedHandler AnatomyObjectRemoved;


    public List<AnatomyObject> SpawnedAnatomyObjects { get; } = new List<AnatomyObject>();

    /// <summary>
    /// Gets the AnatomyObjectManager instance.
    /// </summary>
    public static AnatomyObjectManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var objectManagers = FindObjectsOfType<AnatomyObjectManager>();
                if (objectManagers.Length > 0)
                {
                    s_Instance = objectManagers[0];
                }
                else
                {
                    Debug.LogError("No instance of AnatomyObjectManager exists in the scene.");
                }
            }

            return s_Instance;
        }
    }


    /// <summary>
    /// Invokes spawn event with sending anatomy object.
    /// </summary>
    /// <param name="spawnedObject">Spawned object with AnatomyObject script in it.</param>
    public void OnObjectSpawned(GameObject spawnedObject)
    {
        ShowAllSpawnedObjects();
        if(spawnedObject)
        {
            AnatomyObject anatomySpawnedObject = spawnedObject.GetComponentInChildren<AnatomyObject>();
            if(anatomySpawnedObject != null)
            {
                SpawnedAnatomyObjects.Add(anatomySpawnedObject);
                AnatomyObjectSpawned(anatomySpawnedObject);
            }
            else
            {
                Debug.LogWarning("AnatomyObject component not found in spawned object.");
            }
        }
        else
        {
            Debug.LogError("Spawned object is null.");
        }
    }

    /// <summary>
    /// Invokes select event with sending anatomy object.
    /// </summary>
    /// <param name="selectedObject">Selected object with AnatomyObject script in it.</param>
    public void OnObjectSelected(GameObject selectedObject)
    {
        if(selectedObject != null)
        {
            AnatomyObject anatomySelectedObject = selectedObject.GetComponentInChildren<AnatomyObject>();
            if(anatomySelectedObject != null)
            {
                AnatomyObjectSelected(anatomySelectedObject);
            }
            else
            {
                Debug.LogWarning("AnatomyObject component not found in selected object.");
            }
        }
        else
        {
            Debug.LogError("Selected object is null.");
        }
    }

    /// <summary>
    /// Invokes deselect event with sending anatomy object.
    /// </summary>
    /// <param name="deselectedObject">Deselected object with AnatomyObject script in it.</param>
    public void OnObjectDeselected(GameObject deselectedObject)
    {
        if (deselectedObject != null)
        {
            AnatomyObject anatomyDeselectedObject = deselectedObject.GetComponentInChildren<AnatomyObject>();
            if (anatomyDeselectedObject != null)
            {
                AnatomyObjectDeselected(anatomyDeselectedObject);
            }
            else
            {
                Debug.LogWarning("AnatomyObject component not found in deselected object.");
            }
        }
        else
        {
            Debug.LogError("Deselected object is null.");
        }
    }

    /// <summary>
    /// Invokes remove event with sending anatomy object.
    /// </summary>
    /// <param name="removedObject">Removed object with AnatomyObject script in it.</param>
    public void OnObjectRemoved(GameObject removedObject)
    {
        if (removedObject != null)
        {
            AnatomyObject anatomyRemovedObject = removedObject.GetComponentInChildren<AnatomyObject>(); 
            if(anatomyRemovedObject != null)
            {
                AnatomyObjectRemoved(anatomyRemovedObject);
                SpawnedAnatomyObjects.Remove(SpawnedAnatomyObjects.SingleOrDefault(a => a == anatomyRemovedObject));
            }
            else
            {
                Debug.LogWarning("AnatomyObject component not found in removed object.");
            }
        }
        else
        {
            Debug.LogError("Removed object is null.");
        }
        ShowAllSpawnedObjects();
    }

    public void ShowAllSpawnedObjects()
    {
        foreach(AnatomyObject anatomyObject in SpawnedAnatomyObjects)
        {
            Debug.Log($"{anatomyObject.ObjectName} in instantiated list.");
        }
    }
}
