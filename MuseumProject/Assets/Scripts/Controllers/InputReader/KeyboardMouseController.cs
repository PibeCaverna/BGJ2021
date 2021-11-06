using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputReader
{
    public class KeyboardMouseController : CharacterInput
    {
        // Start is called before the first frame update
        void Awake()
        {
            inputReader = InputSystem.KeyboardMouseTesting();

        }

        public AirconsoleController GetInput()
        {
            return (AirconsoleController)inputReader;
        }

        
    }
}