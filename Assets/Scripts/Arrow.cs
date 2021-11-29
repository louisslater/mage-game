using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public int damage = 3;

    Rigidbody2D rigidBody;
    bool hasHit;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        StartCoroutine(KillArrow());
    }
    IEnumerator KillArrow()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var speed = rigidBody.velocity.magnitude;

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage((int)Mathf.Round(speed) * damage);
            Destroy(gameObject);
        }
    }
}