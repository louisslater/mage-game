using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Damage player when player collides with spikes
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.DamagePlayer(150);
        }
    }
}

