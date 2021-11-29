using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mage : Enemy
{
    public override void Die()
    {
        Debug.Log("Mage.Die");
        currentHealth = 0;
        animator.SetBool("IsDead", true);

        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
    }


}


