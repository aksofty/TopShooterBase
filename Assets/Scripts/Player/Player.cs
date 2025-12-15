using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private float _rotateInput;
    private float _moveInput;
    private Rigidbody2D _rb;

    private Boolean _died = false;

    private void OnEnable()
    {
        EventBus.OnGameOver += PlayerDied;
    }

    private void OnDisable()
    {
        EventBus.OnGameOver -= PlayerDied;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_died)
        {
            return;
        }
        _moveInput = Input.GetAxisRaw("Vertical");
        _rotateInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_died)
        {
            return;
        }

        _rb.MoveRotation(
            _rb.rotation - _rotateInput * rotationSpeed);

        Vector2 moveVector = transform.up * _moveInput;
        _rb.linearVelocity = moveVector * movingSpeed;

    }

    private void PlayerDied()
    {
        _died = true;
        Time.timeScale = 0f;
    }
}
