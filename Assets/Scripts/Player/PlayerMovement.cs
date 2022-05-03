using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [HideInInspector] public bool isMoving;

    private Rigidbody rb;
    private bool isGrounded;

    private void Movement()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .1f);
        isGrounded = colliders.Length > 1;
        if (isGrounded)
            rb.velocity = new Vector3(joystick.Horizontal * speed, .5f, joystick.Vertical * speed);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Destructible"));
    }

    private void FixedUpdate()
    {
        isMoving = (rb.velocity.x == 0 && rb.velocity.z == 0);
        Movement();
    }
}
