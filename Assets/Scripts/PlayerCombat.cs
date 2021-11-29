using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Mage takes damage twice when colliding with player
public class PlayerCombat : MonoBehaviour
{

    public Animator animator;//animates the player

    public Transform attackPoint;//the attack point on the player
    public LayerMask enemyLayers;//contains the enemies

    public float attackRange = 0.5f;//range of player attack
    public int attackDamage = 40;//amount of damage player attack doess

    public float attackDelay = 0.5f;//time between attacks
    float nextAttackTime = 0f;//time of next attack

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //if mouse button is down and enough time has passed then attack
                Attack();
                nextAttackTime = Time.time + attackDelay;
            }
        }
    }

    void Attack()
    {
        //show attack animation for player
        animator.SetTrigger("Attack");

        //get all enemies in attaack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage each enemy in range
        //using a generic Enemy class to we dont have to detect which enemy has been hit e.g. mage, dragon
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        //draw a wire sphere if attacking
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
