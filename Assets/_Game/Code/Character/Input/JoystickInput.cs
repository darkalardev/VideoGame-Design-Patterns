using UnityEngine;

namespace Darkalar.Character
{
    public class JoystickInput : IInput
    {
        private readonly Joystick _joystick;

        public JoystickInput(Joystick joystick)
        {
            _joystick = joystick;
        }
        
        public Vector2 GetDirection()
        {
            Vector2 _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            return _direction;
        }
    }
}