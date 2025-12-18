using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Player : MonoBehaviour
{
    private float _movingSpeed;

    private float _playgroundWidth;
    private float _playgroundHeight;

    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody2D _rb;

    private void Awake()
    {
        Debug.Log("Awake player");  
        _movingSpeed = GameManager.Instance.playerMovingSpeed;
        _playgroundWidth = GameManager.Instance.playgroundWidth;
        _playgroundHeight = GameManager.Instance.playgroundHeight;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseResume();
        }

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {

        Vector2 moveVector = new Vector2(_horizontalInput, _verticalInput).normalized;

        _rb.linearVelocity = moveVector * _movingSpeed;

        float xPosition = Mathf.Clamp(transform.position.x, -_playgroundWidth / 2f, _playgroundWidth / 2f);
        float yPosition = Mathf.Clamp(transform.position.y, -_playgroundHeight / 2f, _playgroundHeight / 2f);

        if (transform.position.x != xPosition || transform.position.y != yPosition)
        {
            transform.position = new Vector2(xPosition, yPosition);
        }
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

}
