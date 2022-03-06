using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public GameObject UiObject;

    //disable hint screen on default
    void Start()
    {
        UiObject.SetActive(false);
    }


    //enable hint screen when player enters trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UiObject.SetActive(true);
        }
    }


    //disable hint screen when player exits trigger
    void OnTriggerExit2D(Collider2D other)
    {
        UiObject.SetActive(false);
    }
}
