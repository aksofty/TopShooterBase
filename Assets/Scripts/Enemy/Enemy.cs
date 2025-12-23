using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour, IEnemy
{

    private float _detectionDistance = 5f;
    private float _movingSpeed = 1f;

    private Rigidbody2D _rb;
    private float _currentPlayerDistance;
    private EnemyState _currentState;
    private GameObject _player;    

    private void Awake()
    { 
        Debug.Log("Awake enemy");       
        _rb = GetComponent<Rigidbody2D>();

        _player = GameManager.Instance.player;
        _currentPlayerDistance = DistanceToPlayer();

        _currentState = new IdleState(this);
        _currentState.Enter();

        _detectionDistance = GameManager.Instance.enemyChasingDistance;
        _movingSpeed = GameManager.Instance.enemyMovingSpeed;
    }

    private void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }

    private void Update()
    {
        _currentPlayerDistance = DistanceToPlayer();
        _currentState?.Update();
    }

    public void MoveToPlayer()
    {
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        _rb.linearVelocity = direction * _movingSpeed;
        RotateTo(direction);
    }

    private void RotateTo(Vector2 direction)
    {

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(targetAngle - 90f);
    }


    private Vector2 PlayerDirection() => (_player.transform.position - transform.position).normalized;
    private float DistanceToPlayer() => Vector2.Distance(transform.position, _player.transform.position);

    public void ChangeState(EnemyState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public Boolean PlayerDetected()
    {
        if (_currentPlayerDistance <= _detectionDistance)
        {
            return true;
        }

        return false;
    }

}
