using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{



    [SerializeField] public float MinHeight = .39f;
    [SerializeField] public float JumpHeight = 1.2f;
    [SerializeField] public CharacterInput Controller;
    [SerializeField] public SpriteDirectionContainer SpriteDirection;
    [SerializeField] CollisionDetection Collider;
    [SerializeField] public ItemsBag Bag;
    
    [SerializeField] LookAt CenterBag;
    [SerializeField] Rigidbody DeadBody;
    public Vector2 LastDirection;

   

    [SerializeField] public StateBase CurrentState;


    public bool Knockbacking = false;

    private void Awake()
    {
        CurrentState.OnStateEnter();
    }

    private void FixedUpdate()
    {
        if (Controller.inputReader.Stick.magnitude > .1f && !Knockbacking)
        {
            LastDirection = Controller.inputReader.Stick;
        }
        CurrentState.CustomUpdate(Time.fixedDeltaTime);


    }

    private void Update()
    {
        //if(LastDirection.magnitude > .01f)
        {
            SpriteDirection.SetCurrentDirection(LastDirection);
            //CenterBag.SetDirection(LastDirection);
        }
    }

    public void ChangeState(StateBase state)
    {
        if(state!= null && state != CurrentState)
        {
            CurrentState = state;
            CurrentState.OnStateEnter();
        }
    }

    public void Knockback()
    {
        Debug.Log("KnockBack");
        Knockbacking = true;
        CurrentState.Knockback();
    }

    public void Dead(Vector3 position)
    {
        SpriteDirection.Dead();

        SpriteDirection.transform.parent = DeadBody.transform;
        Collider.transform.parent = DeadBody.transform;
        
        DeadBody.gameObject.SetActive(true);

        Vector3 force = position - transform.position;
        force.Normalize();
        force += new Vector3(0, 25, 0);
        force.Normalize();
        DeadBody.AddForce(force*100);


        SceneContext.Instance.Death();
    }

    public void GetCollectionable(Collectionable collectionable)
    {
        Bag.AddCollectable(collectionable);
    }
}
