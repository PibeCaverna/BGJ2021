using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;


    private void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * speed * direction;
    }

}
