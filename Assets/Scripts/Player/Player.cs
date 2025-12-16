using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private float _rotateInput;
    private float _moveInput;
    private Rigidbody2D _rb;
    private Boolean _paused = false;

     private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseResume();
        }

        _moveInput = Input.GetAxisRaw("Vertical");
        _rotateInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.MoveRotation(
            _rb.rotation - _rotateInput * rotationSpeed);

        Vector2 moveVector = transform.up * _moveInput;
        _rb.linearVelocity = moveVector * movingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("Столкновение с врагом!");
            GameManager.Instance.GameOver();
        }
    }

    /*private void PlayerDied()
    {
        _died = true;
        Time.timeScale = 0f;
    }*/
}
