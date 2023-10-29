using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class HandAnimation:MonoBehaviour
{
	public Animator animator;

    [SerializeField]
    InputActionProperty m_gripButton;
    public InputActionProperty gripButton {
        get => m_gripButton;
        set => SetInputActionProperty(ref m_gripButton, value);
    }

    [SerializeField]
    InputActionProperty m_triggerButton;
    public InputActionProperty triggerButton {
        get => m_triggerButton;
        set => SetInputActionProperty(ref m_triggerButton, value);
    }

    void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value) {
        if (Application.isPlaying)
            property.DisableDirectAction();

        property = value;

        if (Application.isPlaying && isActiveAndEnabled)
            property.EnableDirectAction();
    }

    public float GetInputValue(InputActionProperty property) {
        var action = property.action;
        if (action == null)
            return 0;

        return action.ReadValue<float>();
    }
	
	void Update() {
        animator.SetFloat("Trigger", GetInputValue(triggerButton));
        animator.SetFloat("Grip", GetInputValue(gripButton));
	}

}