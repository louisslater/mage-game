using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwingknife : MonoBehaviour
{
    public int damage = 2;//how much damge the arrow does
    Rigidbody2D rigidBody;
    bool hasHit;//has the knife hit anything

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if the arrow hasn't hit anything then set the angle to match the velocity
        if (hasHit == false)
        {
            float angle = rigidBody.rotation - 2;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when the arrow hits then make it disappear after a time
        hasHit = true;
        StartCoroutine(KillKnife());
    }

    IEnumerator KillKnife()
    {
        //make arrow disappear after some seconds
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //get speed of knife
        var speed = rigidBody.velocity.magnitude;

        //get the enemy it hit - this could be a dragon or mage for example
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            //damage enemy depending on how fast the knife is going
            enemy.TakeDamage((int)Mathf.Round(speed) * damage);
            //get rid of arrow as it hit an enemy
            Destroy(gameObject);
        }
    }
}
