using UnityEngine;
using UnityEngine.UI;  // For UI if needed

public class HealingScript : MonoBehaviour {
    private bool playerNearby = false;
    public GameObject healedEffect; // Optional effect after healing
    public Animator animator;  // Assign injured NPC's animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E)) // Press "E" to heal
        {
            HealCharacter();
        }
    }

    void HealCharacter()
    {
        Debug.Log("Healing the injured character...");
        animator.Play("Idle"); // Change animation to idle/standing
        if (healedEffect) Instantiate(healedEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 2f); // Remove injured character after healing
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the "Player" tag
        {
            playerNearby = true;
            Debug.Log("Press 'E' to heal");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
