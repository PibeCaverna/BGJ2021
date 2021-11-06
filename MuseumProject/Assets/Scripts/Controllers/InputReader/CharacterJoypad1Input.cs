using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJoypad1Input : CharacterInput
{
    // Start is called before the first frame update
    void Awake()
    {
        inputReader = InputReader.InputSystem.Joy1Testing();
    }

}
