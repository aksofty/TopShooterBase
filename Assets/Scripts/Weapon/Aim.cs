using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector2 _cursorPosition;
    private GameObject _player;
    private float _firingRange;
    private float _minFiringRange;    

    private void Awake()
    {
        _player = GameManager.Instance.player;
        _firingRange = GameManager.Instance.weaponFiringRange;
        _minFiringRange = GameManager.Instance.minWeaponFiringRange;
        //Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (GameManager.Instance.isPaused)
        {
            return;
        }

        _cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float aimDistance = Vector2.Distance(_cursorPosition, _player.transform.position);
        Vector2 direction = (_cursorPosition - (Vector2)_player.transform.position).normalized;

        if (aimDistance >= _firingRange)
        {
            transform.position = (Vector2)_player.transform.position + direction * _firingRange;
        }
        else if (aimDistance <= _minFiringRange)
        {
            transform.position = (Vector2)_player.transform.position + direction * _minFiringRange;
        }
        else
        {
            transform.position = _cursorPosition;
        }

    }

}
