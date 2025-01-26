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

    public float anxiety = 0f;
    public float max_anxiety = 100.0f;
    public float min_anxiety = 0f;
    public float anxiety_coef = 5f;
    public float tranquility_coef = 15f;

    private bool dead = false;

    [SerializeField]
    private Sprite chill_sprite;
    [SerializeField]
    private Sprite anxious_sprite;

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
        if (anxiety >= max_anxiety) {
            dead = true;
        }
        if (_inSafeZone) {
            anxiety =  Mathf.Clamp(anxiety - tranquility_coef * Time.deltaTime, min_anxiety, max_anxiety);
        } else {
            anxiety =  Mathf.Clamp(anxiety + anxiety_coef * Time.deltaTime, min_anxiety, max_anxiety);
        }

        if (anxiety > (max_anxiety * 0.65f)) {
            sprite_rd.sprite = anxious_sprite;
        } else {
            sprite_rd.sprite = chill_sprite;
        }
    }
}
