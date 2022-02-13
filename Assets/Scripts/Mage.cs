using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the mage is a type of enemy 
public class Mage : Enemy
{
    public GameObject MageEnemy; //the mage gameobject
    public GameObject Projectile;//the fireball that the mage fires
    public Transform shotPoint;//the point from which the projectile is fired
    public float launchForce = 7.5f;//the force to fire the projectile
    bool canShoot = true;//true if a fireball can currently be shot

    public void Start()
    {
        //start shooting fireballs straight away
        StartCoroutine(Shoot());

    }

    void Update()
    {
        //calculate the angle to fire the projectile
        //so it will hit the player
        Vector2 firePosition = shotPoint.transform.position;
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        Vector2 direction = playerPosition - firePosition;
        shotPoint.transform.right = direction;
    }

    IEnumerator Shoot()
    {
        //wait for a random time between fireballs
        float spread = Random.Range(-2.0f, 2.0f);
        float ShootDelay = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(ShootDelay);
        if (canShoot)
        {
            //if we can shoot then fire the fireball with the right velocity
            //showing the animation
            animator.SetBool("ProjectileShoot", true);
            yield return new WaitForSeconds(0.2f);
            shotPoint.transform.Rotate(0f, 0f, spread, Space.Self);
            GameObject newProjectile1 = Instantiate(Projectile, shotPoint.position, shotPoint.rotation);
            newProjectile1.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
            animator.SetBool("ProjectileShoot", false);
            StartCoroutine(Shoot());
        }
    }


    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        MageEnemy.SetActive(false);
    }

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
        canShoot = false;
        StartCoroutine(RemoveEnemy());
    }


}


