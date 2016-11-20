using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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

        if (other.gameObject.CompareTag("Memory"))
        {
            Debug.Log("Found some memory:" + other.gameObject.GetComponent<memoryNumber>().number);

            foreach (uint value in numberAlreadyPlayed)
            {
                if (other.gameObject.GetComponent<memoryNumber>().number == value)
                {
                    Debug.Log("Memory has already been seen:" + other.gameObject.GetComponent<memoryNumber>().number);
                    return;
                }
            }

            Debug.Log("middle memory");

            if (animator == null) animator = GetComponent<Animator>();
            if (audioSource == null) audioSource = GetComponent<AudioSource>();

            StartCoroutine(
            createMemory(other.gameObject.GetComponent<memoryNumber>().number,
                other.gameObject.GetComponent<memoryNumber>().suffer,
                other.gameObject.GetComponent<memoryNumber>().image));


            Debug.Log("end memory");

            
        }
    }

    public IEnumerator createMemory(uint memoryNumber, bool suffer, bool image)
    {
        Debug.Log("Trying to play memory");
        if(!memoryPlaying)
        {
            Debug.Log("Found a new memory:" + memoryNumber);

            CharacterMovement c = this.gameObject.GetComponent<CharacterMovement>();
            if(suffer)
            {
                animator.SetBool("isSuffering", true);
                c.dontMove = true;
            }

            // Audio
            audioSource.clip = audioClips[memoryNumber];
            audioSource.Play();

            SlowText o = Instantiate(memoryImage).GetComponent(typeof(SlowText)) as SlowText;
            o.memNum = memoryNumber;
            o.mem = this;

            memoryPlaying = true;

            numberAlreadyPlayed.Add(memoryNumber);

            yield return new WaitForSeconds(wait);

            animator.SetBool("isSuffering", false);
            c.dontMove = false;
            Debug.Log("Memory ended");
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