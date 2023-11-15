using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5CaptionManager : MonoBehaviour
{
    private Transform _mainCameraTransform;
    private CanvasGroup _canvasGrp = null;
    public float distance = 1.5f;

    // Start is called before the first frame update
    private void Awake()
    {
        //Show();
        _mainCameraTransform = Camera.main.transform;
        //Hide();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = _mainCameraTransform.position + _mainCameraTransform.forward * distance;
        transform.LookAt(_mainCameraTransform);
        transform.Rotate(0, 180, 0);
    }
}
