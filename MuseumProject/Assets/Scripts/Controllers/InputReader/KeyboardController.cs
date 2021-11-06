using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputReader
{
    public class KeyboardController : CharacterInput
    {
        // Start is called before the first frame update
        void Awake()
        {
            inputReader = InputSystem.KeyboardTesting();

        }

        public AirconsoleController GetInput()
        {
            return (AirconsoleController)inputReader;
        }

        
    }
}