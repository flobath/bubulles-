using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DetectInteraction : MonoBehaviour
{

    private GameObject _barista = null;

    public string cafeGameSceneName = "CafeGame";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame) {
            // Here are all the interactions the player can do
            if (_barista) {
                SceneManager.LoadScene(cafeGameSceneName);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Barista")) {
            _barista = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (_barista == null) {
            return;
        }
        if (collider.gameObject.CompareTag("Barista")) {
            _barista = null;
        }
    }
}
