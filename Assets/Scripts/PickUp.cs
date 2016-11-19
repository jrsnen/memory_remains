using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{

    private bool holding = false;
    // Use this for initialization
    void Start () 
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(!holding && other.gameObject.CompareTag("PickUp"))
        {
            moveToHand(other.gameObject);
        }
    }


    void moveToHand(GameObject attached)
    {

        attached.transform.parent = this.transform;
        Vector3 hand = new Vector3(1, 3, 0);
        attached.transform.localPosition = hand;
    }
}



