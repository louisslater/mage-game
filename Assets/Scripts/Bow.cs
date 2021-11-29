using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the players bow that fires arrows
public class Bow : MonoBehaviour
{
    public Animator animator;//show the bow being pulled back
    
    public GameObject arrow;//arrow that fires from bow
    
    public float launchForce = 0.5f;//initial force to fire arrow
    public Transform shotPoint;//the point the arrow comes from
    public bool hasShot = false;//has the arrow been shot

    //a lookup for the amount of force to fire the arrow with
    //depending on how long the bow has been pulled back
    public List<float> force = new List<float>() {0.5f, 2.5f, 6.25f, 12.5f, 18.75f, 25.0f };
    public bool canShoot = true;//can an arrow be shot
    public float ShootDelay = 1f;//time between reloads

    // Update is called once per frame
    void Update()
    {
        //set the direction of the bow depending on where the mouse is
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (canShoot == true)
        {
            //if mouse button held down then charge bow
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Charged", false);
                animator.SetBool("Shoot", false);
                animator.SetBool("IsCharging", true);
                hasShot = false;
                StartCoroutine(Charging());
            }
            //when mouse button released then shoot the arrow
            else if (Input.GetMouseButtonUp(0) && hasShot==false)
            {
                animator.SetBool("Charged", false);
                animator.SetBool("Shoot", true);
                animator.SetBool("IsCharging", false);
                //make an arrow and set direction depending on where bow is
                GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
                newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
                //reset to reload bow
                hasShot = true;
                canShoot = false;
                StartCoroutine(Reload());
            }
        }

        IEnumerator Reload()
        {
            //reload the bow after a delay
            yield return new WaitForSeconds(ShootDelay);
            animator.SetBool("Shoot", false);
            canShoot = true;
        }

        IEnumerator Charging()
        {
            //charge up the bow so the force gets bigger for longer times
            for(int i=0; i<force.Count;i++)
            {
                if (hasShot)
                    continue;

                launchForce = force[i];
                yield return new WaitForSeconds(0.23f);
            }

            animator.SetBool("Charged", true);
        }

    }
}
