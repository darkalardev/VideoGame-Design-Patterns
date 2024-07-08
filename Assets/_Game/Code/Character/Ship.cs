using UnityEngine;
using UnityEngine.Serialization;

namespace Darkalar.Character{
    public class Ship : MonoBehaviour
    {
        [Header("---- PARAMETERS ----")]
        [SerializeField] private float _shipSpeed = 4f;
        [SerializeField] private float _limitOnX = 0.03f;
        [SerializeField] private float _limitOnY = 0.97f;
        
        private IInput _input;

        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector2 _direction = GetDirection();
            Move(_direction);
        }

        public void SetInput(IInput input) => _input = input;
        
        private void Move(Vector2 direction)
        {
            transform.Translate(direction * (_shipSpeed * Time.deltaTime));
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            Vector3 _viewportPoint = _camera.WorldToViewportPoint(transform.position);
            _viewportPoint.x = Mathf.Clamp(_viewportPoint.x, _limitOnX, _limitOnY);
            _viewportPoint.y = Mathf.Clamp(_viewportPoint.y, _limitOnX, _limitOnY);
            transform.position = _camera.ViewportToWorldPoint(_viewportPoint);
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}