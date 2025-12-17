using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Player : MonoBehaviour
{
    //[SerializeField] private float movingSpeed = 5f;
    //[SerializeField] private float rotationSpeed = 5f;

    //[SerializeField] private float playgroundWidth = 4f;
    //[SerializeField] private float playgroundHeight = 6f;

    private float _movingSpeed;
    private float _rotationSpeed;

    private float _playgroundWidth;
    private float _playgroundHeight;

    private float _rotateInput;
    private float _moveInput;

    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _movingSpeed = GameManager.Instance.playerMovingSpeed;
        _rotationSpeed = GameManager.Instance.playerRotationSpeed;
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

        _moveInput = Input.GetAxisRaw("Vertical");
        _rotateInput = Input.GetAxisRaw("Horizontal");

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {

        /*_rb.MoveRotation(
            _rb.rotation - _rotateInput * _rotationSpeed);*/

        //Vector2 moveVector = transform.up * _moveInput;

        Vector2 moveVector = new Vector2(_horizontalInput, _verticalInput).normalized;

        _rb.linearVelocity = moveVector * _movingSpeed;



        float xPosition = Mathf.Clamp(transform.position.x, -_playgroundWidth / 2f, _playgroundWidth / 2f);
        float yPosition = Mathf.Clamp(transform.position.y, -_playgroundHeight / 2f, _playgroundHeight / 2f);

        if (transform.position.x != xPosition || transform.position.y != yPosition)
        {
            transform.position = new Vector2(xPosition, yPosition);
        }

        /*transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -playgroundWidth / 2, playgroundWidth / 2),
            Mathf.Clamp(transform.position.y, -playgroundHeight / 2, playgroundHeight / 2));*/


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
