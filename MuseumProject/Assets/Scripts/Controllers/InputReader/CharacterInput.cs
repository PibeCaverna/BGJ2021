using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputReader;

public abstract class CharacterInput : MonoBehaviour
{

    public IInputReader inputReader;

    protected void Update()
    {
        inputReader.ButtonInput();
    }
}
