using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    public float jumpforce = 2.0f;
    public float speed = 1.0f;
    private float moveDirection;
    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        // Check if the Rigidbody2D is moving
        if (_rigidbody.linearVelocity != Vector2.zero) // velocity yerine linearVelocity kullanıldı
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        // Update the velocity based on movement direction
        _rigidbody.linearVelocity = new Vector2(speed * moveDirection, _rigidbody.linearVelocity.y); // velocity yerine linearVelocity kullanıldı

        // Handle jumping
        if (jump == true)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpforce); // velocity yerine linearVelocity kullanıldı
            jump = false;
        }
    }
    void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _renderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _renderer.flipX = false;
            }

            // Koşma tuşu kontrolü
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetFloat("speed", speed * 2); // Koşma animasyonu için hız artırıldı
                speed = 5.0f; // Koşma hızı
            }
            else
            {
                _animator.SetFloat("speed", speed); // Normal hız
                speed = 3.0f; // Normal yürüme hızı
            }
        }
        else if (grounded == true)
        {
            // Stop movement when no input is detected
            moveDirection = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            _animator.SetBool("grounded", true); // Animator'daki grounded parametresini güncelle
        }
    }
}