using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator animator;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    }    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }
    }

    void Update()
    {
        if(Vector3.Distance(transform.position , gm.lastCheckPointPos) < 0.5f)
        {
            animator.SetBool("Active Checkpoint", true);
        }
        else
        {
            animator.SetBool("Active Checkpoint", false);
        }
    }
}
