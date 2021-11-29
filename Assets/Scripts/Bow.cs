using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Animator animator;
    public GameObject arrow;
    public float launchForce = 0.5f;
    public Transform shotPoint;
    public bool hasShot = false;
    public List<float> force = new List<float>() {0.5f, 2.5f, 6.25f, 12.5f, 18.75f, 25.0f };
    public bool canShoot = true;
    public float ShootDelay = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (canShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Charged", false);
                animator.SetBool("Shoot", false);
                animator.SetBool("IsCharging", true);
                hasShot = false;
                StartCoroutine(Charging());
            }

            else if (Input.GetMouseButtonUp(0) && hasShot==false)
            {
                animator.SetBool("Charged", false);
                animator.SetBool("Shoot", true);
                animator.SetBool("IsCharging", false);
                GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
                newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
                hasShot = true;
                canShoot = false;
                StartCoroutine(Reload());
            }
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(ShootDelay);
            animator.SetBool("Shoot", false);
            canShoot = true;
        }

        IEnumerator Charging()
        {
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
