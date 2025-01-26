using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _horizontalInput;
    private float _verticalInput;
    private bool _inSafeZone = false;
    
    private Rigidbody2D rb2D;
    private SpriteRenderer sprite_rd;

    public float health = 100.0f;
    public float depletion_coef = 2f;
    public float increase_coef = 3f;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sprite_rd = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        CalculateMovement(); 
    }

    void CalculateMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (_horizontalInput > 0) {
            sprite_rd.flipX = true;
        } else if (_horizontalInput < 0) {
            sprite_rd.flipX = false;
        }
        Vector2 direction = new Vector2(_horizontalInput * _speed, _verticalInput * _speed);
        rb2D.MovePosition(rb2D.position + direction * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("SafeZone")) {
            _inSafeZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("SafeZone")) {
            _inSafeZone = false;
        }
    }

    void Update ()
    {   
        if (_inSafeZone) {
            if (health >= 100) {
                health = 100;
            } else {
                health -= increase_coef * Time.deltaTime;
            }
        } else {
            health -= depletion_coef * Time.deltaTime;
        }

        // Debug.Log(health);
    }        
}
