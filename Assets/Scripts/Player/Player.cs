using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;

    private Vector2 _movement;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _movement = new Vector2(
            Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Debug.Log(_movement);
        _rb.linearVelocity = _movement * movingSpeed;
    }
}
