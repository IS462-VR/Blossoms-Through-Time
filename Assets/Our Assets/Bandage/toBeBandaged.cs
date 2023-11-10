using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBeBandaged : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null; 
    [SerializeField] GameObject bandage = null;
    [SerializeField] float spawnWaitTime = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            StartCoroutine(PutBandage());
        }
    }
    
    IEnumerator PutBandage()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        bandage.SetActive(true);
        Destroy(gameObject);
    }
}