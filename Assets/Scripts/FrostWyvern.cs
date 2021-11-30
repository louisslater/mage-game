using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the dragon that flies around firing projectiles
[RequireComponent(typeof(Rigidbody2D))]
public class FrostWyvern : Enemy
{
    public GameObject Projectile;//the projectile that the dragon fires
    public Transform shotPoint;//the point from which the projectile is fired
    public float launchForce = 20f;//the force to fire the projectile
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
        float ShootDelay = Random.Range(5.0f, 15.0f);
        yield return new WaitForSeconds(ShootDelay);
        if (canShoot)
        {
            //if we can shoot then fire the projectile with the right velocity
            //showing the animation
            animator.SetBool("ProjectileShoot", true);
            yield return new WaitForSeconds(0.33f);
            GameObject newprojectile1 = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            newprojectile1.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
            animator.SetBool("ProjectileShoot", false);
            StartCoroutine(Shoot());
        }
    }

    public override void Die()
    {
        //handle the dragon dying and make hﬂim fall out of the air
        Debug.Log("Dragon.Die");
        currentHealth = 0;
        animator.SetBool("IsDead", true);
        canShoot = false;

        GetComponent<Rigidbody2D>().gravityScale = 1f;
        //GetComponent<CapsuleCollider2D>().enabled = false;
        //GetComponent<Rigidbody2D>().isKinematic = true;
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //this.enabled = false;
    }

}
