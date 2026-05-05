using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float JumpVelocity = 5f;

    private float vInput;
    private float hInput;
    private bool isJumping;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * MoveSpeed;
        hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        isJumping |= Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);

        Quaternion angleRot = Quaternion.Euler(Vector3.up * hInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

        if (isJumping)
        {
            rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
            isJumping = false;
        }
    }
}
