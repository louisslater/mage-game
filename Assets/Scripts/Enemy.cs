using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this generic class is inherited by dragon and mage etc so that we can just
//call Die without having to handle it for each class
public abstract class Enemy : MonoBehaviour
{
    public Animator animator;//shows the enemy is hurt

    public int maxHealth = 100;//initial health
    public int currentHealth;//current health

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;// start at max health
    }

    void Update()
    { 

    }

    public abstract void TakeDamage(int damage);


    //this is implmented in each enemy such as mage, dragon
    public abstract void Die();

}
