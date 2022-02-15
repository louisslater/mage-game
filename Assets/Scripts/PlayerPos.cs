using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// class to handle setting player position when player reset to a checkpoint 
public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private PlayerHealth health;
    public GameObject player;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

   void Update()
    {
        health = player.GetComponent<PlayerHealth>();

        //reload the scene
        if (health.currentHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
