using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if(_numFound > 0)
        {
            Collider collider = _colliders[0];
            _interactable = collider.GetComponent<IInteractable>();
            if(_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt, collider.transform);

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {

                    _interactable.Interact(this);
                    //_interactionPromptUI.Close(); // Close the UI

                }
            }

        }
        else
        {
           if(_interactable!= null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
