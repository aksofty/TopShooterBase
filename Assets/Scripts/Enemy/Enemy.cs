using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private float catchDistance = 0.1f;
    [SerializeField] private float movingSpeed = 1f;


    private Rigidbody2D _rb;
    private float _currentPlayerDistance;
    private EnemyState _currentState;

    private Boolean _catched = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentPlayerDistance = DistanceToPlayer();

        _currentState = new IdleState(this);
        _currentState.Enter();
    }

    private void FixedUpdate()
    {
        if (_catched)
        {
            return;
        }

        _currentState?.FixedUpdate();
    }

    private void Update()
    {
        _currentPlayerDistance = DistanceToPlayer();
        _currentState?.Update();
    }

    public void MoveToPlayer()
    {
        Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
        _rb.linearVelocity = direction * movingSpeed;
        RotateTo(direction);
    }

    private void RotateTo(Vector2 direction)
    {

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(targetAngle - 90f);
    }

    public void StopMove()
    {

        _rb.linearVelocity = Vector2.zero;

    }


    private Vector2 PlayerDirection() => (player.position - transform.position).normalized;
    private float DistanceToPlayer() => Vector2.Distance(transform.position, player.position);


    public void ChangeState(EnemyState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }


    public Boolean PlayerDetected()
    {

        if (_currentPlayerDistance <= detectionDistance)
        {
            return true;
        }

        return false;
    }

    public Boolean PlayerCatched()
    {
        if (_currentPlayerDistance <= catchDistance)
        {
            return true;
        }

        return false;
    }
}
