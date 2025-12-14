using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private float _rotateInput;
    private float _moveInput;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Vertical");
        _rotateInput = Input.GetAxisRaw("Horizontal");
    }
        

    private void FixedUpdate()
    {
        _rb.MoveRotation(
            _rb.rotation - _rotateInput * rotationSpeed);
        
        Vector2 moveVector = transform.up * _moveInput;
        _rb.linearVelocity = moveVector * movingSpeed;

        //Debug.Log(transform.up);        
    }
}
