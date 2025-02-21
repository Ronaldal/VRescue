using TMPro;
using UnityEngine;

public class HealingTrigger : MonoBehaviour {
    private Animator animator;
    private bool isPlayerNear = false;
    private bool isHealing = false; // Track if healing has started
    public int healCount = 0; // Counter for "H" key presses
    public int healGoal = 10; // Number of times "H" must be pressed to heal
    public GameObject healText;
    public TextMeshProUGUI interactionText;
    public GameObject interactionCanvas;
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.H)) // Press "H" to start healing
        {
            animator.SetTrigger("StartHealing");
            isHealing = true;  // Healing process starts
            healCount = 0;  // Reset healing progress
            Debug.Log("Healing started! Press the button 10 times to heal.");
            interactionText.text = "Healing started! Press the button 10 times to heal";
            healText.SetActive(false);
            interactionCanvas.SetActive(true);


        }

        if (isHealing ) 
        {
            
           
            Debug.Log("Healing progress: " + healCount + "/10");
            
            if (healCount >= healGoal) 
            {
                animator.SetTrigger("HealingComplete"); // Set healing complete trigger
                isHealing = false; 
                Debug.Log("Healing complete!");
                healCount = 0;
                interactionText.text = "Healing complete!";

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !isHealing) // Ensure the Player has the "Player" tag
        {
            isPlayerNear = true;
            healText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            isHealing = false; // Reset healing if the player leaves
            healText.SetActive(false);
            interactionText.text = "";
            interactionCanvas.SetActive(false);

        }
    }
}
