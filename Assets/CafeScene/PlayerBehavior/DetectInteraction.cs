using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class DetectInteraction : MonoBehaviour
{

    private GameObject interactObject = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && interactObject != null) {
            // Here are all the interactions the player can do
            if (interactObject.CompareTag("InteractionSquare")) {
                Vector3 otherTransformPosition = interactObject.transform.position;
                interactObject.transform.position = new Vector3(
                    otherTransformPosition.x + 0.05f,
                    otherTransformPosition.y + 0.05f,
                    otherTransformPosition.z);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("InteractionSquare")) {
            interactObject = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (interactObject == null) {
            return;
        }
        if (collider.gameObject.CompareTag("InteractionSquare") && interactObject.CompareTag("InteractionSquare")) {
            interactObject = null;
        }
    }
}
