using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private float catchDistance = 0.1f;
    [SerializeField] private float movingSpeed = 1f;

    private Rigidbody2D _rb;
    private Boolean _active = true;

    private EnemyState _currentState;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _currentState = new IdleState(this);
        _currentState.Enter();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = math.abs(
            Vector2.Distance(transform.position, player.position));

        Debug.Log(distanceToPlayer);

        if (distanceToPlayer < detectionDistance && _active == true)
        {
            MoveToPlayer();
        }
        else if (distanceToPlayer < catchDistance && _active == true)
        {
            _active = false;
        }
        else if (_active == false)
        {
            return;
        }
    }

    private void Update() {
        _currentState.Update();
    }

    private void MoveToPlayer()
    {
        Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
        _rb.linearVelocity = direction * movingSpeed;
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
   

}
