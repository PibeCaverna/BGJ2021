using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOut : MonoBehaviour
{
    [SerializeField] BonesViewer BonesViewer;
    private void OnTriggerEnter(Collider other)
    {
        var collider = other.GetComponent<CollisionDetection>();
        if (collider)
        {
            var character = collider.Character;

            int items = character.Bag.ItemsCount;
            int bones = BonesViewer.BonesCount;


            if(items < bones)
            {
                SceneContext.Instance.NotYet();
            }
            else
            {
                SceneContext.Instance.EndScene();
            }

        }
    }
}
