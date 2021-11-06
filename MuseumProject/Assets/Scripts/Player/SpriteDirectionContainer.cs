using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionContainer : MonoBehaviour
{
    [SerializeField] float threshold = .1f;
    [SerializeField] Sprite Front;
    [SerializeField] Sprite Rear;
    [SerializeField] Sprite Lateral;
    [SerializeField] public SpriteRenderer Renderer;


    [SerializeField] Sprite DeadFront;
    [SerializeField] Sprite DeadRear;
    [SerializeField] Sprite DeadLateral;

    public void SetCurrentDirection(Vector2 dir)
    {
        if(dir.y >=  threshold)
        {
            Renderer.sprite = Rear;
        }
        if(dir.y <= - threshold)
        {
            Renderer.sprite = Front;
        }

        if(Mathf.Abs(dir.x) > threshold)
        {
            Renderer.sprite = Lateral;
            Renderer.flipX = dir.x > 0;
        }

    }

    public void Dead()
    {
        if(Renderer.sprite == Lateral)
        {
            Renderer.sprite = DeadLateral;
        }
        else
        {
            Renderer.sprite = DeadFront;
        }
        Front = DeadFront;
        Rear = DeadRear;
        Lateral = DeadLateral;
    }

}
