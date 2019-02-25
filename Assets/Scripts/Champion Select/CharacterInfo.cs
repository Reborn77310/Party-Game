using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public Characters character;
    private Transform myName;
    private Image myImage;
    public GameObject usedImage;
    void Awake()
    {
        myImage = GetComponent<Image>();
        myName = transform.GetChild(0);
        usedImage = transform.GetChild(1).gameObject;

        myImage.sprite = character.CharacterSprite;
        //myImage.sprite = Resources.Load("Assets/Resources/Sprites/Personnages" + myName) as Sprite;
        myName.GetComponent<Text>().text = character.Name;
    }
}
