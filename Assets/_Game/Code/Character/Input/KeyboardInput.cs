using UnityEngine;

namespace Darkalar.Character
{
    public class KeyboardInput : IInput
    {
        public Vector2 GetDirection()
        {
            Vector2 _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return _direction;
        }
    }
}