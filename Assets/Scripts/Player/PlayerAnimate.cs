using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// Player animator
/// </summary>
public class PlayerAnimate : MonoBehaviour
{
    enum Direction { Left = -1, Front = 0, Right = 1 }

    public int animationFps = 10;
    public SpriteAtlas animationAtlas;

    SpriteRenderer spriteRenderer;
    float animationTimer = 0.0f;
    string currentAnimation = "Front_Idle_1";
    Direction direction = Direction.Front;
    bool isWalking = false;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationAtlas ??= Resources.Load<SpriteAtlas>("Assets/Sprites/PlayerAtlas.spriteatlasv2");
        spriteRenderer.sprite = animationAtlas.GetSprite(currentAnimation);
    }

    void Update()
    {
        animationTimer += Time.deltaTime;
        if (direction == Direction.Front)
        {
            CycleThrough("Front_Idle_1");
        }
        else
        {
            string dir = direction == Direction.Left ? "Left" : "Right";
            if (isWalking)
            {
                CycleThrough(
                    $"{dir}_Walk_1",
                    $"{dir}_Walk_2",
                    $"{dir}_Walk_3",
                    $"{dir}_Walk_2"
                );
            }
            else
            {
                CycleThrough($"{dir}_Idle_1");
            }
        }
    }

    void CycleThrough(params string[] animations) {
        int index = (int)(animationTimer * animationFps) % animations.Length;
        if (currentAnimation != animations[index])
        {
            currentAnimation = animations[index];
            spriteRenderer.sprite = animationAtlas.GetSprite(currentAnimation);
        }
    }

    public void AnimateMovement(float horizontal)
    {
        isWalking = horizontal != 0;
        if (isWalking)
        {
            var newDirection = horizontal > 0 ? Direction.Right : Direction.Left;
            if (direction != newDirection) { animationTimer = 0.0f; }
            direction = newDirection;
        }
    }

    public void AnimateSeeFront() {
        direction = Direction.Front;
        animationTimer = 0.0f;
    }

    public void AnimateSetDirection(int direction) {
        Debug.Assert(direction == -1 || direction == 0 || direction == 1);
        this.direction = (Direction)direction;
        animationTimer = 0.0f;
    }

    public int GetDirection() {
        return (int)direction;
    }
}
