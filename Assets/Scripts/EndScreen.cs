using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject timer;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Start()
    {
        timer.GetComponent<Timer>().StopStopwatch();
    }
}
