using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{

    [SerializeField] MoveObject MoveObject;


    private void OnTriggerEnter(Collider other)
    {
        var disp = other.GetComponent<ObjectDispawner>();
        if (disp)
        {
            Destroy(MoveObject.gameObject);
        }
    }

}
