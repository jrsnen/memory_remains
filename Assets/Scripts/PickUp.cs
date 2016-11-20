using UnityEngine;
using System.Collections;
using System.Linq;
public class PickUp : MonoBehaviour 
{
    public const string DROP_BUTTON = "E";
    public Transform handPlaceholder;
    public Animation animation;

    private const string PICKUP_TAG = "PickUp";
    private const string DoorTrigger_TAG = "DoorTrigger";
    private const string DRAWER_TAG = "Drawer";
    private const string Key0_TAG = "Key0";
    private const string Key1_TAG = "Key1";

    private bool isDoorOpen = false;

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
        //log("gameObject.tag =  " + gameObject.tag);
        if(!holding && other.gameObject.tag.Contains(PICKUP_TAG))
        {
            holding = true;
            attachedObject = other.gameObject;
        }
        doorTrigger(other);
        drawerTrigger(other);
    }
    

    void checkDropItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && holding)
        {
            //log(attachedObject.name);
            attachedObject.transform.parent = null;
            attachedObject.transform.localPosition = transform.position;
            holding = false;
        }
    }
    
    void doorTrigger(Collider other)
    {
        if (isDoorOpen) return;
        log("doorTrigger starrted");
        if (other.gameObject.CompareTag(DoorTrigger_TAG) && holding && attachedObject.tag.Contains(Key0_TAG))
        {
            log("doorTrigger");
            animation.Play();
            isDoorOpen = true;
        }
    }

    void drawerTrigger(Collider other)
    {
        if (other.gameObject.CompareTag(DRAWER_TAG) && holding && attachedObject.tag.Contains(Key1_TAG))
        {
            log("drawer opens");
            //animation.Play();
        }
    }

    // Remove this for debug
    void log(string text)
    {
        Debug.Log(text);
    }
}