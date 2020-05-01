using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
