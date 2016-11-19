﻿using UnityEngine;
using System.Collections;
using System.Linq;
public class PickUp : MonoBehaviour 
{
    public const string DROP_BUTTON = "E";
    public Transform handPlaceholder;
    public Animation animation;

    private bool holding = false;
    private bool firstTimeEnteringExitTrigger = false;
    GameObject attachedObject;
    // Use this for initialization
    void Start () 
    {
    }

    void Update()
    {
        if (holding)
        {
            attachedObject.transform.position = handPlaceholder.transform.position;
            attachedObject.transform.rotation = handPlaceholder.transform.rotation;
        }
        checkDropItem();
    }

    void OnTriggerEnter(Collider other)
    {
        log("trigger enter, holding = " +holding);
        if(!holding && other.gameObject.CompareTag("PickUp"))
        {
            holding = true;
            attachedObject = other.gameObject;
        }
        doorTrigger(other);
    }
    

    void checkDropItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && holding)
        {
            log(attachedObject.name);
            attachedObject.transform.parent = null;
            attachedObject.transform.localPosition = transform.position;
            holding = false;
        }
    }
    
    void doorTrigger(Collider other)
    {
        if (other.gameObject.CompareTag("DoorTrigger") && holding)
        {
            log("staying");
            animation.Play();
        }
    }

    // Remove this for debug
    void log(string text)
    {
        Debug.Log(text);
    }
}