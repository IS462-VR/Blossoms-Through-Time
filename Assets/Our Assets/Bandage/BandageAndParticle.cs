using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BandageAndParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null; 
    [SerializeField] GameObject placedBandage = null;
    
    [SerializeField] float spawnWaitTime = 1f;

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     StartCoroutine(Heal());
        // }
    }   

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         healingParticles.Play();
    //     }
    // }
    public void Heal()
    {
            StartCoroutine(PutBandage());
    }
    
    IEnumerator PutBandage()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        placedBandage.SetActive(true);
    }
}
