using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyNotificationManager : MonoBehaviour
{
    [SerializeField] private NotificationManager _privacyNotification;
    [SerializeField] private float _privacyNotificationDelay;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("OpenInAppPrivacyNotification", _privacyNotificationDelay);       
    }

    public void OpenInAppPrivacyNotification()
    {
        if(_privacyNotification != null)
        {
            if (PlayerPrefs.GetInt("PrivacyNotificationPlayed") == 0)
            {
                _privacyNotification.OpenNotification();
                //PlayerPrefs.SetInt("PrivacyNotificationPlayed", 1);
            }
        }
        else
        {
            Debug.LogError("Google privacy notification field is not found!");
        }
    }
}
