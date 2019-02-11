using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public Characters character;
    private Transform myName;
    private Image myImage;
    void Awake()
    {
        myImage = GetComponent<Image>();
        myName = transform.GetChild(0);

        myImage.sprite = character.CharacterSprite;
        myName.GetComponent<Text>().text = character.Name;
    }
}
