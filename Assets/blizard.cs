using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blizard : MonoBehaviour
{

    public int damage = 10;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillBlizard());
    }

    IEnumerator KillBlizard()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.DamagePlayer(damage);
            //this.enabled = false;
        }
    }
}