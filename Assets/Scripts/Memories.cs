using UnityEngine;
using System.Collections;

public class Memories : MonoBehaviour
{
    public GameObject memoryImage;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Memory"))
        {
            memoryImage.SetActive(true);
            Debug.Log("Found memory");
        }
    }
}


