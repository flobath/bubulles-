using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CalculateMovement(); 
    }

    void CalculateMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(_horizontalInput * _speed, _verticalInput * _speed);
        rb2D.MovePosition(rb2D.position + direction * Time.fixedDeltaTime);
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
