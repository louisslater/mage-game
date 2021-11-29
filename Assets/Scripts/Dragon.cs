using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dragon : Enemy
{
    public GameObject Fireball;
    public Transform shotPoint;
    public float launchForce = 4f;

    public void Start()
    {
        //float ShootDelay = Random.Range(0.25f,1.0f);
        StartCoroutine(Shoot());
    }

    void Update()
    {

        Vector2 firePosition = shotPoint.transform.position;
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        Vector2 direction = playerPosition - firePosition;
        shotPoint.transform.right = direction;
    }

        IEnumerator Shoot()
    {
        float ShootDelay = Random.Range(3.0f,4.0f);
        yield return new WaitForSeconds(ShootDelay);
        GameObject newFireball = Instantiate(Fireball, shotPoint.position, shotPoint.rotation);
        newFireball.GetComponent<Rigidbody2D>().velocity = shotPoint.transform.right * launchForce;
        StartCoroutine(Shoot());
    }

    public override void Die()
    {
        Debug.Log("Dragon.Die");
        currentHealth = 0;
        animator.SetBool("IsDead", true);

        GetComponent<Rigidbody2D>().gravityScale = 1f;
        //GetComponent<CapsuleCollider2D>().enabled = false;
        //GetComponent<Rigidbody2D>().isKinematic = true;
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //this.enabled = false;
    }

}
