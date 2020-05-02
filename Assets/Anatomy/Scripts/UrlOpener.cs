using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlOpener : MonoBehaviour
{
    [SerializeField] private string Url;

    public void OpenUrl()
    {
        Application.OpenURL(Url);
    }
}
