using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the dragon that flies around firing fireballs
[RequireComponent(typeof(Rigidbody2D))]
public class Dragon : Enemy
{
    public AudioSource dragonDie;
    public AudioSource dragonShoot;

    public GameObject DragonEnemy; //the fire dragon gameobject
    public GameObject Fireball;//the fireball that the dragon fires
    public Transform shotPoint;//the point from which the fireball is fired
    public float launchForce = 6f;//the force to fire the fireball
    bool canShoot = true;//true if a fireball can currently be shot

    public void Start()
    {
        //start shooting fireballs straight away
        StartCoroutine(Shoot());
        
    }
    void Update()
    {
        //calculate the angle to fire the fireball
        //so it will hit the player
        Vector2 firePosition = shotPoint.transform.position;
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        Vector2 direction = playerPosition - firePosition;
        shotPoint.transform.right = direction;
    }

    IEnumerator Shoot()
    {
        //wait for a random time between fireballs
        float ShootDelay = Random.Range(1.5f,2.0f);
        yield return new WaitForSeconds(ShootDelay);
        if (canShoot)
        {
            //if we can shoot then fire the fireball with the right velocity
            //showing the animation
            animator.SetBool("FireballShoot", true);
            dragonShoot.Play();
            yield return new WaitForSeconds(0.33f);
            GameObject newFireball1 = Instantiate(Fireball, shotPoint.position, shotPoint.rotation);
            newFireball1.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
            animator.SetBool("FireballShoot", false);
            StartCoroutine(Shoot());
        }
    }

    IEnumerator RemoveDragon()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        DragonEnemy.SetActive(false);
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
        //handle the dragon dying and make him fall out of the air
        Debug.Log("Dragon.Die");
        currentHealth = 0;
        animator.SetBool("IsDead", true);
        canShoot = false;
        dragonDie.Play();
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        StartCoroutine(RemoveDragon());
    }

}
