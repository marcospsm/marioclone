using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public SpriteRenderer spriteR { get; private set; }
    private PlayerMovement movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run;

    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void OnEnable()
    {
        spriteR.enabled = true;
    }

    private void OnDisable()
    {
        spriteR.enabled = false;
    }

    private void LateUpdate()
    {
        run.enabled = movement.running;
        
        if (movement.jumping)
        {
            spriteR.sprite = jump;
        }

        else if (movement.sliding)
        {
            spriteR.sprite = slide;
        }

        else if (!movement.running)
        {
            spriteR.sprite = idle;
        }
    }
}
