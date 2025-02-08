using UnityEngine;

public class HealingTrigger : MonoBehaviour {
    private Animator animator;
    private bool isPlayerNear = false;
    private bool isHealing = false; // Track if healing has started
    public int healCount = 0; // Counter for "H" key presses
    public int healGoal = 10; // Number of times "H" must be pressed to heal

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // Press "E" to start healing
        {
            animator.SetTrigger("StartHealing");
            isHealing = true;  // Healing process starts
            healCount = 0;  // Reset healing progress
            Debug.Log("Healing started! Press 'H' 10 times to heal.");
        }

        if (isHealing ) // Press "H" to heal
        {
            
           
            Debug.Log("Healing progress: " + healCount + "/10");

            if (healCount >= healGoal) 
            {
                animator.SetTrigger("HealingComplete"); // Set healing complete trigger
                isHealing = false; 
                Debug.Log("Healing complete!");
                healCount = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the "Player" tag
        {
            isPlayerNear = true;
            Debug.Log("Player is near. Press 'E' to heal.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            isHealing = false; // Reset healing if the player leaves
            Debug.Log("Player left healing area.");
        }
    }
}
