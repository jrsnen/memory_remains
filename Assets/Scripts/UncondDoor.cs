using UnityEngine;
using System.Collections;

public class UncondDoor : MonoBehaviour {

    private bool isUnCondiDoorOpen = false;

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            if (isUnCondiDoorOpen) return;
            Debug.Log("yes");
                GetComponentInParent<Animation>().Play();
                isUnCondiDoorOpen = true;
        }
    }

    void unCondDoorTrigger(Collider other)
    {
        
    }
}
