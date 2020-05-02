using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    private void Start()
    {
        //if(PlayerPrefs.GetInt("IsFirstAppLaunch") == 1)
        //{
        //    PlayerPrefs.SetInt("IsFirstAppLaunch", 0);
        //}
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
