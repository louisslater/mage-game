using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Animator animator;

    public int damage = 10;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator FireballExplode()
    {
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //var speed = rigidBody.velocity.magnitude;

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
