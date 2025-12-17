using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform aim;
    [SerializeField] private float rotationSpeed = 0.1f;

    private Vector2 _direction;

    private void Awake()
    {
        _direction = Vector2.zero;
    }

    private void Update()
    {
        _direction = (aim.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.isPaused)
        {
            return;
        }

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);   
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);     
    }
}
