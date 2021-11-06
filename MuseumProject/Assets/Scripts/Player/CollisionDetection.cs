using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    [SerializeField] public Character Character;
    [SerializeField] SoundData KnockbackSound;
    private void OnTriggerEnter(Collider other)
    {

        var collectionable = other.GetComponent<Collectionable>();
        if (collectionable)
        {
            Character.GetCollectionable(collectionable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var staticObj = collision.collider.GetComponent<StaticObject>();

        if (staticObj)
        {
            if (KnockbackSound)
            {
                SoundManager.Instance.PlayEffect(KnockbackSound.GetRandom());
            }
            Character.Knockback();
        }
        else
        {
            var dynamicObj = collision.collider.GetComponent<DynamicObject>();

            if (dynamicObj)
            {
                Character.Dead(collision.transform.position);
            }
        }


    }

}
