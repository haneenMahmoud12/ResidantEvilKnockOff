using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Assign your specific Animator Controller asset here
    [SerializeField] private RuntimeAnimatorController specificAnimatorController;

    private void Start()
    {
        // Get the Animator component attached to the player if not assigned already
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Assign the specific Animator Controller if provided in the Inspector
        if (specificAnimatorController != null)
        {
            animator.runtimeAnimatorController = specificAnimatorController;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the "Pick" trigger parameter to true
            animator.SetTrigger("Pick");

            // Optionally, you can disable the item object or perform other actions
            gameObject.SetActive(false);
        }
    }
}


