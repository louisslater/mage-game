using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwknife : MonoBehaviour
{
    public GameObject knife;//knife object to be thrown

    public AudioSource throwSound;

    public float launchForce = 12f;//initial force to throw knife
    public Transform shotPoint;//the point the arrow comes from
    public bool hasShot = false;//has the arrow been shot


    public bool canShoot = true;//can an arrow be shot
    public float ShootDelay = 3f;//time between reloads

    void Update()
    {
        //set the direction of the throw depending on where the mouse is
        Vector2 knifePosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - knifePosition;
        transform.right = direction;

        if (canShoot == true)
        {
            //throw knife when player right clicks
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(ThrowKnife());
                canShoot = false;
            }
        }

        IEnumerator ThrowKnife()
        {
            GameObject newKnife1 = Instantiate(knife, shotPoint.position, shotPoint.rotation);
            throwSound.Play();
            newKnife1.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            yield return new WaitForSeconds(0.15f);
            GameObject newKnife2 = Instantiate(knife, shotPoint.position, shotPoint.rotation);
            throwSound.Play();
            newKnife2.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            yield return new WaitForSeconds(0.15f);
            GameObject newKnife3 = Instantiate(knife, shotPoint.position, shotPoint.rotation);
            throwSound.Play();
            newKnife3.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            //reload the bow after a delay
            yield return new WaitForSeconds(ShootDelay);
            canShoot = true;
        }
    }
}
