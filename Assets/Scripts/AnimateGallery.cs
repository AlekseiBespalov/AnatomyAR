using TMPro;
using UnityEngine;

public class AnimateGallery : MonoBehaviour
{
    public Animator menuAnimator;
    [Header("SETTINGS")]
    public bool openAtStart = false;
    bool isOpen;
    void Start()
    {
        if(openAtStart == true)
        {
            menuAnimator.Play("GalleryOpen");
            isOpen = true;
        }
        //else
        //{
        //    menuAnimator.Play("Minimize");
        //    animatedButton.Play("HTE Hamburger");
        //    isOpen = false;
        //}
    }
    public void Animate(bool state)
    {
        if (state == true)
            menuAnimator.Play("GalleryClose");
        else if(state == false)      
            menuAnimator.Play("GalleryOpen");
    }
}
