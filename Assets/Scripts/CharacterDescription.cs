using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDescription : MonoBehaviour
{
    public Characters character;
    private Transform myName;
    private SpriteRenderer mySprite;

    void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();

        mySprite.sprite = character.CharacterSprite;
        //myImage.sprite = Resources.Load("Assets/Resources/Sprites/Personnages" + myName) as Sprite;
    }
}
