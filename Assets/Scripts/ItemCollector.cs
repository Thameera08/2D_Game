using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Player_Life playerLife; // Add this field

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Lifeboy: " + cherries;

            float originalSpeed = playerMovement.OriginalSpeed;
            playerMovement.ChangeSpeed(2 * originalSpeed);
            StartCoroutine(ResetPlayerSpeedAfterDelay(3f));

            // Make the player invulnerable for 2 seconds after collecting a cherry
            playerLife.MakeInvulnerable();
        }
    }

    private IEnumerator ResetPlayerSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerMovement.ResetSpeed();
    }
}
