using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the dragon that flies around firing projectiles
[RequireComponent(typeof(Rigidbody2D))]
public class FrostWyvern : Enemy
{
    public AudioSource dragonHurt;

    public GameObject DragonGFX;//the graphics and animations of the dragon
    public GameObject Projectile;//the projectile that the dragon fires
    public GameObject Projectile2;//the projectile that the dragon fires
    public Transform shotPoint;//the point from which the projectile is fired
    public float launchForce = 15f;//the force to fire the projectile
    public float launchForce2 = 1.5f;//the force to fire the projectile
    bool canShoot = true;//true if a projectile can currently be shot

    public void Start()
    {
        //start shooting projectiles straight away
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
        //wait for a random time between projectiles
        float shootDelay = Random.Range(0.0f, 6.0f);
        int shootType = Random.Range(1, 3);
        float spread = Random.Range(-3.0f, 3.0f);
        yield return new WaitForSeconds(shootDelay);
        if (canShoot)
        {
            //if we can shoot then fire the projectile with the right velocity
            //showing the animation
            if (shootType == 1)
            {
                animator.SetBool("ProjectileShoot", true);
                yield return new WaitForSeconds(0.46f);
                
                //fire 3 projectiles
                shotPoint.transform.Rotate(0f, 0f, spread, Space.Self);
                GameObject newprojectile1 = Instantiate(Projectile, shotPoint.position, shotPoint.rotation);
                newprojectile1.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
                
                shotPoint.transform.Rotate(0f, 0f, spread, Space.Self);
                GameObject newprojectile2 = Instantiate(Projectile, shotPoint.position, shotPoint.rotation);
                newprojectile2.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
                
                shotPoint.transform.Rotate(0f, 0f, spread, Space.Self);
                GameObject newprojectile3 = Instantiate(Projectile, shotPoint.position, shotPoint.rotation);
                newprojectile3.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
                
                yield return new WaitForSeconds(0.4f);
                animator.SetBool("ProjectileShoot", false);
            }
            if (shootType == 2)
            {
                animator.SetBool("ProjectileShoot2", true);
                yield return new WaitForSeconds(0.46f);
                shotPoint.transform.Rotate(0f, 0f, -5, Space.Self);
                GameObject newprojectile4 = Instantiate(Projectile2, shotPoint.position, shotPoint.rotation);
                newprojectile4.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce2;
                shotPoint.transform.Rotate(0f, 0f, 5f, Space.Self);
                GameObject newprojectile5 = Instantiate(Projectile2, shotPoint.position, shotPoint.rotation);
                newprojectile5.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce2;
                shotPoint.transform.Rotate(0f, 0f, 0f, Space.Self);
                GameObject newprojectile6 = Instantiate(Projectile2, shotPoint.position, shotPoint.rotation);
                newprojectile6.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce2;
                yield return new WaitForSeconds(0.4f);
                animator.SetBool("ProjectileShoot2", false);
            }
            StartCoroutine(Shoot());
        }
    }

    public override void TakeDamage(int damage)
    {
        //reduce enemy health and die when no health is left
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        dragonHurt.Play();

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

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        DragonGFX.GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }

}
