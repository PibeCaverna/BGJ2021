using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFrontObject : MonoBehaviour
{
    [SerializeField] int numberOfPositions = 20;
    public Transform Target;

    Vector3[] lastPositions;

    int counter;
    bool FirstRound = true;

    private void Awake()
    {
        lastPositions = new Vector3[numberOfPositions];
    }

    private void FixedUpdate()
    {
        if (Target)
        {
            lastPositions[counter] = Target.position;

            if (FirstRound)
            {
                if (counter == numberOfPositions - 1)
                    FirstRound = false;
            }
            else
            {
                Vector3 pos = lastPositions[(counter + 1) % numberOfPositions];
                transform.position = pos;
            }
            counter = (counter + 1) % numberOfPositions;
        }
    }

}
