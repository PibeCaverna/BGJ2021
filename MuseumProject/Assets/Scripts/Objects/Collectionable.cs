using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour
{
    [SerializeField] public Collider Trigger;
    [SerializeField] public FollowFrontObject FollowObject;

    [SerializeField] Transform MoveTransform;

    float timer = 0;
    [SerializeField] float Amplitude = .2f;
    [SerializeField] float Frecuency = 1;

    Vector3 CurrentPosition;

    private void Start()
    {
        CurrentPosition = MoveTransform.position;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        var deltaPos = Vector3.zero;

        deltaPos.y = Mathf.Sin(timer * Mathf.PI * Frecuency) * Amplitude;

        MoveTransform.transform.position = CurrentPosition + deltaPos;

    }
}
