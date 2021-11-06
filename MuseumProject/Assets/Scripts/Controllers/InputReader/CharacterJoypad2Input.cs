using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJoypad2Input : CharacterInput
{
    // Start is called before the first frame update
    void Awake()
    {
        inputReader = InputReader.InputSystem.Joy2Testing();

    }

}
