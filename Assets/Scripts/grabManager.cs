using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabManager : MonoBehaviour
{
    private BoxCollider collider;

    public void onGrabbed()
    {
        // collider.enabled = false;
    }

    public void onReleased()
    {
        // collider.enabled = false;
    }

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
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
