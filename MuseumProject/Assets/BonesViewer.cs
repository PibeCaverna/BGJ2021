using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesViewer : MonoBehaviour
{

    [SerializeField] MoveToTarget MoveToTarget;
    [SerializeField] Collectionable[] Bones;
    [SerializeField] float timeOverBones = 3;

    [SerializeField] Transform PlayerTarget;

    public int BonesCount => Bones.Length;

    float timer = 0;

    bool showing = false;
    bool transition = false;

    int index = 0;

    public bool Transition => transition;


    public void ShowCameraTransition()
    {
        PlayerTarget = CameraFollowTarget.Target;
        index = 0;
        showing = false;
        timer = 0;

        MoveToTarget.SetTarget(Bones[index].transform);
        CameraFollowTarget.Target = MoveToTarget.transform;

        transition = true;

    }

    private void Update()
    {
        if (transition)
        {
            if (showing)
            {
                timer += Time.deltaTime;
                if(timer > timeOverBones)
                {
                    showing = false;
                    index++;
                    if(index < Bones.Length)
                    {
                        MoveToTarget.SetTarget(Bones[index].transform);
                    }
                    else
                    {
                        MoveToTarget.SetTarget(PlayerTarget.transform);
                    }
                }
            }
            else
            {
                if (MoveToTarget.IsOverTarget())
                {
                    if (index < Bones.Length)
                    {
                        showing = true;
                        timer = 0;
                    }
                    else
                    {
                        CameraFollowTarget.Target = PlayerTarget.transform;
                        transition = false;
                    }
                }
               
                
            }
        }
    }




}
