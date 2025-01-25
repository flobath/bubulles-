using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _horizontalInput;
    private float _verticalInput;

    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    void Update()
    {
        CalculateMovement(); 
    }

    void CalculateMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_horizontalInput, _verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
        
        //restrict players vertical movement in the screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5), 0);
        
        //wrap players horizontal movement in the screen
        if (transform.position.x > 9.40f)
        {
            transform.position = new Vector3(-9.40f, transform.position.y, 0);
        } else if (transform.position.x < -9.40f)
        {
            transform.position = new Vector3(9.40f, transform.position.y, 0); 
        }
    }
}
