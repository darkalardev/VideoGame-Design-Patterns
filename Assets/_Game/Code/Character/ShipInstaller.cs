using UnityEngine;

namespace Darkalar.Character
{
    public class ShipInstaller : MonoBehaviour
    {
        [Header("---- REFERENCES ----")] 
        [SerializeField] private Joystick _joystick;

        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.SetInput(GetInput());
        }

        private IInput GetInput()
        {
#if UNITY_ANDROID
            return new JoystickInput(_joystick);
#endif
            Destroy(_joystick.gameObject);
            return new KeyboardInput();
        }
    }
}