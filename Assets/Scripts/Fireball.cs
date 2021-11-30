using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Animator animator;//animation for the fireball

    public int damage = 10;//how much damage the fireball does

    Rigidbody2D rigidBody;//rigid body part of fireball

    // Start is called before the first frame update
    void Start()
    {
        //set fireball to last a fixed number of seconds
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(KillFireball());
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
    IEnumerator KillFireball()
    {
        //kill fireball after some seconds
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator FireballExplode()
    {
        //show explosion animation then kill fireball
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(0.41f);
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
            StartCoroutine(FireballExplode());
            //this.enabled = false;
            //Destroy(gameObject);
        }
    }
}
