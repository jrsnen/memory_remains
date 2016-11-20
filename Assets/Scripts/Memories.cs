using UnityEngine;
using System.Collections.Generic;

public class Memories : MonoBehaviour
{
    public GameObject memoryImage;

    public float wait = 3.0f;
    public AudioClip[] audioClips;

    private bool memoryPlaying = false;

    private Animator animator;
    private AudioSource audioSource;
    private List<uint> numberAlreadyPlayed = new List<uint>();

    void start()
    {
        //animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (uint value in numberAlreadyPlayed)
        {
            if (other.gameObject.GetComponent<memoryNumber>().number == value) return;
        }
        if (other.gameObject.CompareTag("Memory"))
        {
            if (animator == null) animator = GetComponent<Animator>();
            if (audioSource == null) audioSource = GetComponent<AudioSource>();
            createMemory(other.gameObject.GetComponent<memoryNumber>().number,
                other.gameObject.GetComponent<memoryNumber>().suffer,
                other.gameObject.GetComponent<memoryNumber>().image);
            // Audio
            audioSource.clip = audioClips[other.gameObject.GetComponent<memoryNumber>().number];
            audioSource.Play();

            numberAlreadyPlayed.Add(other.gameObject.GetComponent<memoryNumber>().number);
        }
    }

    public void createMemory(uint memoryNumber, bool suffer, bool image)
    {
        if(!memoryPlaying)
        {
            if(suffer)
                animator.SetBool("IsSuffering", true);

            CharacterMovement c = this.gameObject.GetComponent<CharacterMovement>();
            c.enabled = false;

            

            c.enabled = true;

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