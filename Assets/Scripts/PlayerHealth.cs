using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages the health of the player
public class PlayerHealth : MonoBehaviour
{
    public Animator animator;//animator for player dying

    public AudioSource playerHurt;

    public int maxHealth = 150;//full health amount for player
    public int currentHealth;//players current health


    public HealthBar healthBar;//health bar for player

    // Start is called before the first frame update
    void Start()
    {
        //set to max health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(RegenerateHealth());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(0.5f);
        if (currentHealth < maxHealth && currentHealth != 0)
        {
            currentHealth = currentHealth + 1;
            healthBar.SetHealth(currentHealth);
        }
        StartCoroutine(RegenerateHealth());
    }

    public void DamagePlayer(int damage)
    {
        playerHurt.Play();

        //take damage off player
        currentHealth -= damage;
        //animator.SetTrigger("Hurt");

        //set health bar
        healthBar.SetHealth(currentHealth);

        //if player has no health then make him die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //set health to zero and show die animation
        currentHealth = 0;
        animator.SetBool("IsDead", true);

    }
}
