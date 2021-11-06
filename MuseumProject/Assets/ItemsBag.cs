using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBag : MonoBehaviour
{
    [SerializeField] List<Collectionable> collectionables = new List<Collectionable>();
    [SerializeField] SoundData CollectedSound;

    public int ItemsCount => collectionables.Count;

    internal void AddCollectable(Collectionable collectionable)
    {
        collectionable.Trigger.enabled = false;
        collectionable.enabled = false;
        if (collectionables.Count > 0)
        {
            collectionable.FollowObject.Target = collectionables[collectionables.Count - 1].transform;
        }
        else
        {
            collectionable.FollowObject.Target = transform;
        }
        collectionables.Add(collectionable);

        if (CollectedSound)
        {
            SoundManager.Instance.PlayEffect(CollectedSound.GetRandom());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .03f);
    }

}
