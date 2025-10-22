using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public Transform cameraTransform;
    public Transform groundCheck;

    public float speed = 5f;
    public float sprintSpeed = 8f;
    public float jumpForce = 5f;
    public float groundDistance = 0.3f;
    public LayerMask groundLayer;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        float inputMagnitude = direction.magnitude;
        animator.SetFloat("Speed", inputMagnitude);
        animator.SetBool("isRunning", isSprinting);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDir.normalized * currentSpeed * Time.fixedDeltaTime);
        }
    }
}
