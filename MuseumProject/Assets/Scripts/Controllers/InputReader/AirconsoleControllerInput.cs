using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputReader;
public class AirconsoleControllerInput : CharacterInput
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
