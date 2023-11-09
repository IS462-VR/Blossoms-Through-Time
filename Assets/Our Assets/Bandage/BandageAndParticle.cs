using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BandageAndParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null; 
    [SerializeField] GameObject bandage = null;
    
    [SerializeField] GameObject healingPotion = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Heal());
        }
    }   

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         healingParticles.Play();
    //     }
    // }
    
    IEnumerator Heal()
    {
        // healingPotion.SetActive(false);
        healingParticles.Play();
        yield return new WaitForSeconds(1f);
        bandage.SetActive(true);
    }
}
