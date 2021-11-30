using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DragonGFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        //flip the enemy graphics and point to shoot from depending on which
        //x direction it's moving in
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
