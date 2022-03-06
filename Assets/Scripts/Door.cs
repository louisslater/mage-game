using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//the door at the end of the scene that completes the level and loads the next one
public class Door : MonoBehaviour
{
    private GameMaster gm;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            gm.lastCheckPointPos.Set(0f, -0.5f);

        }
    }
}
