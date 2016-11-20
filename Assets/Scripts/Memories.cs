using UnityEngine;
using System.Collections;

public class Memories : MonoBehaviour
{
    public GameObject memoryImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Memory"))
        {
            createMemory(other.gameObject.GetComponent<memoryNumber>().number);
        }
    }

    void createMemory(uint memoryNumber)
    {
        SlowText o = Instantiate(memoryImage).GetComponent(typeof(SlowText)) as SlowText;
        o.memNum = memoryNumber;

        Debug.Log("Found memory");

    }

}


