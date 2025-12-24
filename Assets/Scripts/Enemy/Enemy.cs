using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour, IEnemy
{
    private GameObject _player; 
    private float _detectionDistance = 5f;
    private float _movingSpeed = 1f;

    private Rigidbody2D _rb;
    private EnemyState _currentState;
       

    private void Awake()
    { 
        Debug.Log("Awake enemy");  
        _player = GameManager.Instance.player;
        _detectionDistance = GameManager.Instance.enemyChasingDistance;
        _movingSpeed = GameManager.Instance.enemyMovingSpeed;

        _rb = GetComponent<Rigidbody2D>();
        _currentState = new IdleState(this);
        _currentState.Enter();
    }

    private void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }

    private void Update()
    {
        _currentState?.Update();
    }

    public void MoveToPlayer()
    {
        _rb.linearVelocity = PlayerDirection * _movingSpeed;                
    }

    public void StopMoving()
    {
        _rb.linearVelocity = Vector2.zero;      
    }

    public void RotateTo(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(targetAngle - 90f);
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public Vector2 PlayerDirection => (_player.transform.position - transform.position).normalized;
    public float DistanceToPlayer => Vector2.Distance(transform.position, _player.transform.position);

    public Boolean PlayerDetected()
    {
        if (DistanceToPlayer <= _detectionDistance)
        {
            return true;
        }

        return false;
    }

}
