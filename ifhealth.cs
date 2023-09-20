using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ifhealth : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;

    private SpriteRenderer sr;

    public Playerhealthcontroller status;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = image1; // set the sprite to sprite1
    }

    void Update()
    {
        if (status.playerhealth <= 50) // If the space bar is pushed down
        {
            ChangeTheDamnSprite(); // call method to change sprite
        }
        if (status.playerhealth == 10) // If the space bar is pushed down
        {
            ChangeTheDamnSpritee(); // call method to change sprite
        }
    }


    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == image1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = image2;
        }
    }
        void ChangeTheDamnSpritee()
    {
            if (spriteRenderer.sprite == image2) // if the spriteRenderer sprite = sprite1 then change to sprite2
            {
                spriteRenderer.sprite = image3;
            }
        }
  /*  void ChangeTheDamnSpriteee()
    {
        if (spriteRenderer.sprite == image2) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = image3;
        }
    } */
}