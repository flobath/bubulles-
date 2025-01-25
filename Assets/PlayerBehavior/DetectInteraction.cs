using UnityEngine;

public class DetectInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("In the function");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("In the Keyboard trigger");
            Destroy(collider.gameObject);
        }
    }
}
