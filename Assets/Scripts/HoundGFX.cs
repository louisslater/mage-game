using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles the movement of the hounds
public class HoundGFX : MonoBehaviour
{
    public GameObject HoundEnemy; //the mage gameobject

    // Update is called once per frame
    void Update()
    {
        Vector2 MagePosition = HoundEnemy.transform.position;
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


