using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roselleGrab : MonoBehaviour
{
    private Rigidbody roselleRb;
    // Start is called before the first frame update
    void Start()
    {
        roselleRb = GetComponent<Rigidbody>();
        roselleRb.isKinematic = true;
        roselleRb.useGravity = false;
    }

    public void OnGrabbed() // This should be called by your VR interaction script when the object is grabbed
    {
        Debug.Log("Grabbed");
        roselleRb.isKinematic = false;
        roselleRb.useGravity = true;
    }

    public void OnReleased() // This should be called by your VR interaction script when the object is released
    {
        Debug.Log("Released");
        roselleRb.isKinematic = false;
        roselleRb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
