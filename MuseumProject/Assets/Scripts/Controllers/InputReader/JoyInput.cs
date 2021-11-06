using UnityEngine;
using UnityEngine.Assertions;

namespace InputReader
{
    /// <summary>
    /// default = WASD - JKL
    /// </summary>
    internal class JoyInput : InputReaderKey
    {

        
        public JoyInput()
        {
            _interactKey = KeyCode.JoystickButton0;
            _jumpKey = KeyCode.JoystickButton1;
            _rollKey = KeyCode.JoystickButton2;
            _rollKey = KeyCode.JoystickButton3;
            _xAxis = "Joystick1Horizontal";
            _yAxis = "Joystick1Vertical";
        }
		
        public JoyInput(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify)
        {
            _interactKey = interact;
            _jumpKey = jump;
            _rollKey = tool;
            _attackKey = notify;
            _xAxis = xAxis;
            _yAxis = yAxis;
        }

        
    }
}