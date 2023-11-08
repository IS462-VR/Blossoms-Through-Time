using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class boundaryController : MonoBehaviour
{
    public static boundaryController Instance { get; private set; }
    private Dictionary<tickManager.FlowerType, bool> collectedFlowers = new Dictionary<tickManager.FlowerType, bool>();
    public GameObject initialBoundary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            foreach (tickManager.FlowerType type in Enum.GetValues(typeof(tickManager.FlowerType)))
            {
                collectedFlowers[type] = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FlowerCollected(tickManager.FlowerType type, bool state)
    {
        collectedFlowers[type] = state;
        CheckAllFlowersCollected();
    }

    private void CheckAllFlowersCollected()
    {
        foreach (bool state in collectedFlowers.Values)
        {
            if (!state)
            {
                return;
            }
        }
        LiftBoundary();
    }

    void LiftBoundary()
    {
        initialBoundary.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
