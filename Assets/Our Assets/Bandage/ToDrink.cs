using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDrink : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null;
    [SerializeField] float spawnWaitTime = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            StartCoroutine(GiveDrink());
        }
    }

    IEnumerator GiveDrink()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        Destroy(gameObject);
    }
}

