using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// an ice spike weapon fired at the player 
public class Icespike : MonoBehaviour
{

    public int damage = 1;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(KillIceSpike());
    }

    IEnumerator KillIceSpike()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var speed = rigidBody.velocity.magnitude;

        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.DamagePlayer((int)Mathf.Round(speed) * damage);
            //this.enabled = false;
            if (speed >= 5f)
            {
                rigidBody.isKinematic = true;
                transform.parent = player.transform;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().isKinematic = true;
            }
            StartCoroutine(KillIceSpike());
        }
    }
}
