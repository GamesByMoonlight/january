﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Class to control the behavior of the arms
/// </summary>
public class RightArm : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    private Animator animator;


    public static bool Eating { get; set; }

    void Start()
    {
        Eating = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerAction();
        }

    }

    void PlayerAction()
    {
        RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);

        if(hit.transform == null || hit.transform.CompareTag("Food") == false)
        {
            TryThrowShuriken();
        } else
        {
            if(Eating == false)
            {
                Mochi targetMochi = hit.transform.GetComponent<Mochi>();
                targetMochi.BeginEating();
                Eating = true;
                animator.SetBool("eatMochi", Eating);
                Invoke("FinishedEating", targetMochi.eatTime);  // If we change the Mochi eating behavior, we're going to have to change this
            }
            
        }

    }

    void FinishedEating()
    {
        Eating = false;
        animator.SetBool("eatMochi", Eating);
    }

    void TryThrowShuriken()
    {
        if(Eating == false)
        {
            animator.SetTrigger("throwShuriken");  // Further logic for shuriken spawning is found in ShurikenThrow.cs
        }
        

    }

}



