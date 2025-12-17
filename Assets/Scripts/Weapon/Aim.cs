using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector2 _aimPosition;

    private void Awake()
    {        
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if(GameManager.Instance.isPaused)
        {
            return;
        }
        
        _aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _aimPosition;
    }

}
