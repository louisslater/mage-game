using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the fireball projectiles that the mage fires
public class Mageprojectile : MonoBehaviour
{

    public Animator animator;//animation for the projectile

    public AudioSource Explode;

    public int damage = 15;//how much damage the projectile does

    Rigidbody2D rigidBody;//rigid body part of projectile

    // Start is called before the first frame update
    void Start()
    {
        //set fireball to last a fixed number of seconds
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(KillProjectile());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hasHit = true;
        // StartCoroutine(KillArrow());
    }
    IEnumerator KillProjectile()
    {
        //kill projectile after some seconds
        yield return new WaitForSeconds(3f);
        StartCoroutine(ProjectileExplode());
    }

    IEnumerator ProjectileExplode()
    {
        //show explosion animation then kill fireball
        Explode.Play();
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(0.41f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //var speed = rigidBody.velocity.magnitude;

        //if fireball hits player then make player take damage
        //and explode fireball
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.DamagePlayer(damage);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(ProjectileExplode());
        }
    }
}

