using UnityEngine;
using UnityEngine.Assertions;

namespace InputReader
{
    /// <summary>
    /// default = WASD - JKL
    /// </summary>
    internal class KeyboardInput : InputReaderKey
    {

        public KeyboardInput()
        {
            _interactKey = KeyCode.Space;
            _jumpKey = KeyCode.K;
            _rollKey = KeyCode.L;
            _xAxis = "KeyboardHorizontal";
            _yAxis = "KeyboardVertical";
        }
		
        public KeyboardInput(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify)
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