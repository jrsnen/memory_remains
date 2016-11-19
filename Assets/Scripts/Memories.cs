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
            SlowText o = Instantiate(memoryImage).GetComponent(typeof(SlowText)) as SlowText;
            o.memNum = other.gameObject.GetComponent<memoryNumber>().number;

            Debug.Log("Found memory");
        }
    }
}


