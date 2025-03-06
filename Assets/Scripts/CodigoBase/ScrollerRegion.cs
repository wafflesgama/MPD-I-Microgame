using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerRegion : MonoBehaviour
{
    public Vector3 spawnOffset;

    private bool hasSpawned;

    public TriggerChecker checker;


    private void Awake()
    {
        checker.OnTriggered.AddListener(OnRegionTriggered);
    }
    void OnRegionTriggered()
    {
        if (hasSpawned) return;

        var newRegion = GameObject.Instantiate(gameObject, transform.parent);
        newRegion.transform.position = transform.position + spawnOffset;

        hasSpawned = true;
    }
}
