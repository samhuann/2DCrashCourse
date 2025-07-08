using UnityEngine;

public class TouchingDirections : MonoBehaviour
{

    Rigidbody2D rb;

    public ContactFilter2D castFilter;

    CapsuleCollider2D touchingCollider;
    public float groundDistance = 0.5f;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    Animator animator;

    [SerializeField]
    private bool _isGrounded;

    public bool isGrounded
    {
        get { return _isGrounded; }
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.IsGrounded, value);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
