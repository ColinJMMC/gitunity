using UnityEngine;

public class RockInteraction : MonoBehaviour
{
    // Hoeveel kracht er nodig is om de speler omhoog te lanceren
    public float jumpForce = 500f;

    private void OnCollisionEnter(Collision collision)
    {
        // Controleert of het object dat de trigger raakt de speler is
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verwijdert de rock uit de wereld
            Destroy(gameObject);

            // Probeer een Rigidbody op de speler te vinden
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Reset verticale snelheid en voeg sprongkracht toe
                playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x, 0, playerRigidbody.linearVelocity.z);
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
            else
            {
                Debug.LogWarning("Speler heeft geen Rigidbody component.");
            }
        }
    }
}
