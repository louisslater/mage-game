using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the hounds that run along the ground
public class Hound : Enemy
{
    public AudioSource HoundHurt;
    public AudioSource HoundBite;

    public Transform target;//the point to move towards

    public LayerMask playerLayers;//contains the player
    public GameObject HoundEnemy; //the skull hound gameobject
    public Transform attackPoint;//the point from which the hound attacks from
    bool isDead = false;//true if hound can currently attack

    public float attackRange = 0.3f;//range of attack
    public int attackDamage = 15;//amount of damage attack does

    public float attackDelay = 0.5f;//time between attacks
    float nextAttackTime = 0f;//time of next attack

    public float speed = 0.075f;//the speed the enemy moves

    Rigidbody2D rb;//the rigidbody part of the enemy

    public Transform enemyGFX;//enemy graphics

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackDelay;
        }
    }

    void FixedUpdate()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= 2.5f)
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        if (isDead == false)
        {
            if (distanceToTarget <= 15)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed + Random.Range(-0.10f,0.1f));
            }
        }

    }

        void Attack()
    {
        if (isDead == false)
        {
            //get all enemies in attaack range
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            //damage each enemy in range
            //using a generic Enemy class to we dont have to detect which enemy has been hit e.g. mage, dragon
            foreach (Collider2D player in hitPlayer)
            {
                HoundBite.Play();
                player.GetComponent<PlayerHealth>().DamagePlayer(attackDamage);
            }
        }
    }

    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        HoundEnemy.SetActive(false);
    }


    public override void TakeDamage(int damage)
    {
        HoundHurt.Play();
        //reduce enemy health and die when no health is left
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        //handle the dragon dying and make him fall out of the air
        currentHealth = 0;
        animator.SetBool("IsDead", true);
        isDead = true;
        StartCoroutine(RemoveEnemy());
    }

}
