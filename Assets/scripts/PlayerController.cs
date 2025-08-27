using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 charpos;
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _renderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charpos = transform.position;
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        
        _rigidbody2D.linearVelocity = new Vector2(speed, 0f);
        charpos = new Vector3(charpos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charpos.y);
        transform.position = charpos;

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _renderer.flipX = true;
        }
        
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charpos.x, charpos.y, -1.0f);
    }
}
