using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private float _rotationSpeed;
    private Vector2 _direction;
    private Transform _player;

    private void Awake()
    {
        _rotationSpeed = GameManager.Instance.weaponRotationSpeed;
        _direction = Vector2.zero;
    }

    private void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = (cursorPosition - (Vector2)transform.position).normalized;

        //Debug.DrawRay((Vector2)transform.position + _direction, _direction * 10f);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    private void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + _direction, _direction * 2f, 10f);
        
        if (hit.collider != null)
        {
            Debug.LogFormat(hit.collider.gameObject.name);
            if (hit.collider.gameObject.GetComponent<Enemy>() != null)
            {
                Debug.Log("Enemy die!");

                hit.collider.gameObject.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPaused)
        {
            return;
        }
        RotateWeapon();
    }


    private void RotateWeapon()
    {
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed);
    }
}
