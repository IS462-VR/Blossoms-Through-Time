using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tickManager : MonoBehaviour
{
    public RawImage rawImage;
    public MeshRenderer meshRenderer;
    public enum FlowerType { Neem, Roselle }
    public FlowerType type;

    public void onGrabbed()
    {
        ChangeOpacity(1f);
        meshRenderer.enabled = false;
        boundaryController.Instance.FlowerCollected(type, true);
    }

    public void onReleased()
    {
        ChangeOpacity(0f);
        meshRenderer.enabled = true;
        boundaryController.Instance.FlowerCollected(type, false);
    }

    private void ChangeOpacity(float opacity)
    {
        Color color = rawImage.color;
        color.a = opacity;
        rawImage.color = color;
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
