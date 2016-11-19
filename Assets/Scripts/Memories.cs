using UnityEngine;
using System.Collections;

public class Memories : MonoBehaviour
{
    public GameObject memoryImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Memory"))
        {
            //memoryImage.SetActive(true);
            Instantiate(memoryImage);
            Debug.Log("Found memory");
        }
    }
}


