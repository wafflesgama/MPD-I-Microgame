using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerChecker : MonoBehaviour
{
    //[InfoBox("Do not forget that either this/other object needs a Rigidbody to TriggerCheck!")]

    public bool isChecking = true;
    public bool searchInRigidbody;
    public LayerMask layersToCheck;
    public string tagToSearch;

    public bool hasObject { get; private set; }
    public GameObject obj { get; private set; }
    public Rigidbody2D objRb { get; private set; }

    public UnityEvent OnTriggered = new UnityEvent();
    public UnityEvent OnUnTriggered = new UnityEvent();


    private void Awake()
    {
        hasObject = true;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isChecking) return;
        if (!IsObject(other)) return;

        obj = searchInRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
        objRb = other.attachedRigidbody;
        hasObject = true;

        OnTriggered.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isChecking) return;
        if (!IsObject(other)) return;

        obj = null;
        objRb = null;
        hasObject = false;
        OnUnTriggered.Invoke();
    }

    private bool IsObject(Collider2D other)
    {
        if (searchInRigidbody)
        {
            if (!layersToCheck.DoesMaskContainsLayer(other.attachedRigidbody.gameObject.layer)) return false;
            if (!string.IsNullOrEmpty(tagToSearch) && LayerMask.LayerToName(other.attachedRigidbody.gameObject.layer) == tagToSearch) return false;
        }
        else
        {
            if (!layersToCheck.DoesMaskContainsLayer(other.gameObject.layer)) return false;
            if (!string.IsNullOrEmpty(tagToSearch) && LayerMask.LayerToName(other.gameObject.layer) == tagToSearch) return false;
        }

        return true;
    }



}

public static class PhysicsUtils
{
    public static bool DoesMaskContainsLayer(this LayerMask layermask, int layer)
    {
        return layermask == (layermask | (1 << layer));
    }

}
