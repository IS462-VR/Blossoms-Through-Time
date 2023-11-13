using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Scene4Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private CanvasGroup _canvasGrp = null;

    private DialogueText _currentDialogueText = null;
    private AudioSource _currentLinesAudioSource = null;
    public float textSpeed;
    //public GameObject _naviSceneLead;
    //public GameObject _naviSceneForest;


    public AudioClip naviSound;
    public AudioClip humanSound;

    private Transform _mainCameraTransform;
    private Canvas _canvas;
    private Vector3 _colliderPosition;

    public Boolean hasFinished;
    public int currentIndex = 0;

    public GameObject clipboardInstruction;


    private void Awake()
    {
        _canvasGrp = GetComponent<CanvasGroup>();
        _canvas = GetComponent<Canvas>();
        _mainCameraTransform = Camera.main.transform;
        Hide();

        _hasActiveDialogue = false;
        clipboardInstruction.SetActive(false);
    }

    private void Show() { _canvasGrp.alpha = 1.0f; }
    private void Hide() { _canvasGrp.alpha = 0.0f; }

    private bool _hasActiveDialogue = false;
    private Coroutine _typeLineCoroutine = null;
    private void Update()
    {

    }

    //private void LateUpdate()
    //{
    //    transform.position = _mainCameraTransform.position + _mainCameraTransform.forward * 1.5f;
    //    transform.LookAt(_mainCameraTransform);
    //    transform.Rotate(0, 180, 0);
    //}


    public void LoadDialogueData(DialogueText inputDialogueText, AudioSource audioSource, Vector3 colliderPosition)
    {
        _currentDialogueText = inputDialogueText;
        _currentLinesAudioSource = audioSource;
        //_colliderPosition = colliderPosition;
        //transform.position = colliderPosition + Vector3.up * 0.9f;
    }

    public void PlayAudio()
    {
        if (_currentDialogueText == null)
        {
            Debug.LogError("DialogueText has yet to be loaded first!!!");
            return;
        }

        switch (_currentDialogueText.audioType)
        {
            case DialogueText.eAudioType.Navi:
                {
                    _currentDialogueText.audioSource.clip = naviSound;
                    break;
                }
            case DialogueText.eAudioType.Human:
                {
                    _currentDialogueText.audioSource.clip = humanSound;
                    break;
                }
            default:
                {
                    Debug.LogWarning("No sound implemented for this type: " + _currentDialogueText.audioType);
                    break;
                }
        }

        _currentDialogueText.audioSource.Play();
    }

    public void StartDialogue()
    {

        if (_currentDialogueText == null)
        {
            Debug.LogError("DialogueText has yet to be loaded first!!!");
            return;
        }

        if (!_currentDialogueText.hasDialogueStarted)
        {

            if (_currentDialogueText.hasDialogueFinished)
            {
                return;
            }

            _currentDialogueText.hasDialogueStarted = true;
            textComponent.text = string.Empty;
            Show();
            _hasActiveDialogue = true;
            if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
            _typeLineCoroutine = StartCoroutine(TypeLine());
            if (_currentDialogueText.lineIndex < _currentDialogueText.lines.Length)
            {
                PlayAudio();
            }
        }
        else
        {

            if (_currentDialogueText.lineIndex < _currentDialogueText.lines.Length - 1)
            {
                _currentDialogueText.lineIndex++;
                Show();
                textComponent.text = string.Empty;
                _hasActiveDialogue = true;
                if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
                _typeLineCoroutine = StartCoroutine(TypeLine());

                PlayAudio();
            }


        }

    }

    public void EndDialogue()
    {
        Debug.Log("dialogueended");
        if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
        Hide();
        _hasActiveDialogue = false;


        if (_currentDialogueText.lineIndex == _currentDialogueText.lines.Length - 1)
        {
            _currentDialogueText.hasDialogueFinished = true;
        }

        if (currentIndex == _currentDialogueText.lines.Length)
        {
            hasFinished = true;
            clipboardInstruction.SetActive(true);
        }
    }


    IEnumerator TypeLine()
    {
        currentIndex = _currentDialogueText.lineIndex;
        while (currentIndex < _currentDialogueText.lines.Length)
        {
            _currentLinesAudioSource.clip = _currentDialogueText.lineClips[currentIndex];
            _currentLinesAudioSource.Play();

            foreach (char c in _currentDialogueText.lines[currentIndex].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            Debug.Log("end of line");

            if (currentIndex == 0)
            {
                yield return new WaitForSeconds(1f);

            }
            else
            {
                yield return new WaitForSeconds(2f);

            }

            currentIndex++;

            Debug.Log(currentIndex.ToString());
            textComponent.text = string.Empty;

            if (currentIndex == _currentDialogueText.lines.Length)
            {
                Debug.Log("reach last line. ending dialog");
                EndDialogue();
            }

        }



    }

    private void NextLine()
    {
        if (_currentDialogueText.lineIndex < _currentDialogueText.lines.Length - 1)
        {
            _currentDialogueText.lineIndex++;
            textComponent.text = string.Empty;
            if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
            _typeLineCoroutine = StartCoroutine(TypeLine());
            if (_currentDialogueText.lineIndex < _currentDialogueText.lines.Length)
            {
                _currentDialogueText.audioSource.Play();
            }
        }
        else { EndDialogue(); }
    }

}
