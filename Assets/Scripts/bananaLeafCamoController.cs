using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaLeafCamoController : MonoBehaviour
{
    public GameObject[] bananaLeafCamo;
    public GameObject bananaLeaf;
    public GameObject camoSound;
    public float delay = 1.0f;
    // Start is called before the first frame update
    public void activateCamo()
    {
        camoSound.GetComponent<AudioSource>().Play();
        foreach (var leaf in bananaLeafCamo)
        {
            MeshRenderer renderer = leaf.GetComponent<MeshRenderer>();
            renderer.enabled = true;
        }

        Invoke("disableBananaLeaf", delay);
    }

    private void disableBananaLeaf()
    {
        bananaLeaf.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
