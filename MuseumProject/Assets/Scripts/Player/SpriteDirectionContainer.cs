using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionContainer : MonoBehaviour
{
    [SerializeField] float threshold = .1f;
    [SerializeField] Sprite Front;
    [SerializeField] Sprite Rear;
    [SerializeField] SpriteRenderer Renderer;



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
            Renderer.flipX = dir.x > 0;
        }

    }

}
