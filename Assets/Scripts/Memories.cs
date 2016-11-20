﻿using UnityEngine;
using System.Collections;

public class Memories : MonoBehaviour
{
    public GameObject memoryImage;

    public float wait = 3.0f;

    private bool memoryPlaying = false;

    private Animator animator;

    void start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Memory"))
        {
            createMemory(other.gameObject.GetComponent<memoryNumber>().number,
                other.gameObject.GetComponent<memoryNumber>().suffer,
                other.gameObject.GetComponent<memoryNumber>().image);
        }
    }

    public void createMemory(uint memoryNumber, bool suffer, bool image)
    {
        if(!memoryPlaying)
        {
            animator.SetBool("IsWalking", true);

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