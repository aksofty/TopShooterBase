using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private float playgroundWidth = 4f;
    [SerializeField] private float playgroundHeight = 6f;

    private float _rotateInput;
    private float _moveInput;
    private Rigidbody2D _rb;

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



        float xPosition = Mathf.Clamp(transform.position.x, -playgroundWidth / 2, playgroundWidth / 2);
        float yPosition = Mathf.Clamp(transform.position.y, -playgroundHeight / 2, playgroundHeight / 2);

        if (transform.position.x != xPosition || transform.position.y != yPosition)
        {
            transform.position = new Vector2(xPosition, yPosition);
            Debug.Log("wall");
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

    /*private void PlayerDied()
    {
        _died = true;
        Time.timeScale = 0f;
    }*/
}
