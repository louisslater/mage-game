using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageGFX : MonoBehaviour
{
    public GameObject MageEnemy; //the mage gameobject

    // Update is called once per frame
    void Update()
    {
        Vector2 MagePosition = MageEnemy.transform.position;
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        Vector2 direction = playerPosition - MagePosition;

        if (direction.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direction.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
