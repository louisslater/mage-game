using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls running and jumping of the player
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;//class that moves the player
    public Animator animator;//shows animations of the player

    public float runSpeed = 40f;//the speed player can run

    float horizontalMove = 0f;//horizontal movement

    bool jump = false;//is player jumping

    // Update is called once per frame
    void Update()
    {
        //make player move horizontally
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //set player to jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {
        //move player
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
