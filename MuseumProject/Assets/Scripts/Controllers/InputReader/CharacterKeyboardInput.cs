using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKeyboardInput : CharacterInput
{
    // Start is called before the first frame update

   
    void Awake()
    {
        inputReader = InputReader.InputSystem.KeyboardTesting();
    }

    
}
