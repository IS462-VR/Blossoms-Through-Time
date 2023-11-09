using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{

    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    private Transform _targetTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false); ;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion rotation = _mainCam.transform.rotation;

        Vector3 lookAtPoint = transform.position + rotation * Vector3.forward;

        // Make the GameObject look at the calculated point
        transform.LookAt(lookAtPoint);
        //transform.LookAt(transform.position + rotation * Vector3.forward, rotation + Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText, Transform targetInteractable)
    {
        _targetTransform = targetInteractable;
        _promptText.text = promptText;
        transform.position = targetInteractable.transform.position + Vector3.up * 1.5f;
        transform.SetParent(targetInteractable.transform, true);
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        _promptText.text = "";
       IsDisplayed=false;
    }
}
