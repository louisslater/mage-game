using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the mage is a type of enemy 
public class Mage : Enemy
{

    public override void TakeDamage(int damage)
    {
        //reduce enemy health and die when no health is left
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        //set mage to be dead and disable him
        Debug.Log("Mage.Die");
        currentHealth = 0;
        animator.SetBool("IsDead", true);

        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
    }


}


