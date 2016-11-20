using UnityEngine;
using System.Collections;

public class Memories : MonoBehaviour
{
    public GameObject memoryImage;

    private bool memoryPlaying = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Memory"))
        {
            createMemory(other.gameObject.GetComponent<memoryNumber>().number);
        }
    }

    public void createMemory(uint memoryNumber)
    {
        if(!memoryPlaying)
        {
        SlowText o = Instantiate(memoryImage).GetComponent(typeof(SlowText)) as SlowText;
        o.memNum = memoryNumber;
        o.mem = this;

        memoryPlaying = true;

        Debug.Log("Found memory");
        }
        else
        {
            Debug.Log("Memory was already Playing!");
        }
    }

    public void memoryEnded()
    {
        memoryPlaying = false;
    }

}