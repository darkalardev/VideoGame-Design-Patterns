using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _limitOnX = 0.03f;
    [SerializeField] private float _limitOnY = 0.97f;


    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var direction = GetDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * (_speed * Time.deltaTime));
        ClampFinalPosition();
    }

    private void ClampFinalPosition()
    {
        var viewportPoint = _camera.WorldToViewportPoint(transform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, _limitOnX, _limitOnY);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, _limitOnX, _limitOnY);
        transform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }

    private Vector2 GetDirection()
    {
        return new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
}
