using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//this tells the enemy how and when to move
public class EnemyAI : MonoBehaviour
{
    public Transform enemyGFX;//enemy graphics
    public Transform shotPoint;//the point that the enemy shoots from

    public Transform target;//the point to move towards

    public float speed = 200f;//the speed the enemy moves
    public float nextWaypointDistance = 3f;//the way point increment

    Path path;//the path to take
    int currentWaypoint = 0;//current waypoint distance
    bool reachedEndOfPath = false;//have reached the end of the path

    Seeker seeker;//the object that plots the path
    Rigidbody2D rb;//the rigidbody part of the enemy

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //keep updating the path
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        //if seeker has finished then start another
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        //reset the path
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //if there is no path do nothing
        if (path == null)
            return;

        //check if we've got to end of path
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        //set the direction and force for the enemy
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        //if we havent reached the distance then increase the way point value
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //flip the enemy graphics depending on which
        //x direction it's moving in
        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            shotPoint.localPosition = new Vector3(0.15f, 0f, 0f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            shotPoint.localPosition = new Vector3(-0.15f, 0f, 0f);
        }
    }
}
