using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    private bool isInvulnerable = false; // Flag to track invulnerability
    private float invulnerabilityDuration = 2f; // Duration of invulnerability in seconds

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the invulnerability period has ended
        if (isInvulnerable && Time.time >= invulnerabilityDuration)
        {
            isInvulnerable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (!isInvulnerable)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        // Restart level after a delay (e.g., 1 second)
        Invoke("RestartLevel", 1f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MakeInvulnerable()
    {
        // Make the player invulnerable for the specified duration
        isInvulnerable = true;
        Invoke("EndInvulnerability", invulnerabilityDuration);
    }

    private void EndInvulnerability()
    {
        isInvulnerable = false;
    }
}
