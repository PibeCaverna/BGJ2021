using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] GameObject Prefab;
    [SerializeField] float TimeBettween = 6;

    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > TimeBettween)
        {
            Instantiate(Prefab, transform.position, Prefab.transform.rotation);
            timer = 0;
        }
    }

}
