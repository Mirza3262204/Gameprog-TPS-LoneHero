using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float JumpVelocity = 5f;
    public bool IsOnGround = true;
    public float GroundCheckRadius = 0.3f;
    public LayerMask GroundLayer;
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    private float _vInput;
    private float _hInput;
    private bool _isJumping;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _isJumping |= Input.GetKeyDown(KeyCode.J);

        IsOnGround = Physics.CheckSphere(transform.position, GroundCheckRadius, GroundLayer);

        if(Input.GetKeyDown(KeyCode.J) && IsOnGround)
        {
            _isJumping = true;
        }

        _isShooting |= Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.fixedDeltaTime);

        Quaternion angleRot = Quaternion.Euler(Vector3.up * _hInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }

        if(_isShooting )
        {
            Vector3 spawnPos = transform.position + transform.forward * 1f;
            GameObject newBullet = Instantiate(Bullet, spawnPos, this.transform.rotation);

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.linearVelocity = this.transform.forward * BulletSpeed;
            _isShooting = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, GroundCheckRadius);
    }
}