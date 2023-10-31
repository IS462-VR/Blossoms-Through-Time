using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioSource myFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}