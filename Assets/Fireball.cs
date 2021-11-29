using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public int damage = 10;

    Rigidbody2D rigidBody;
    bool hasHit;

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
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //var speed = rigidBody.velocity.magnitude;

        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
