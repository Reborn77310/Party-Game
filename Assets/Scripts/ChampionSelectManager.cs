using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampionSelectManager : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject[] SelectedPlayers;
    public GameObject SelectionSquare;
    [SerializeField] private int actualPlayerSelected = 0;

    private bool leftAxisInUse = false;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("L_XAxis");
        if (Mathf.Abs(horizontal) > 0.2f)
        {
            if (!leftAxisInUse)
            {
                if (horizontal < 0.2f)
                {
                    if (actualPlayerSelected != 0)
                    {
                        actualPlayerSelected--;
                        leftAxisInUse = true;
                    }
                }
                else if (horizontal > 0.2f)
                {
                    if (actualPlayerSelected != 8)
                    {
                        actualPlayerSelected++;
                        leftAxisInUse = true;
                    }
                }
            }
            SelectionSquare.transform.position = Players[actualPlayerSelected].transform.position;
        }
        else if (leftAxisInUse)
        {
            leftAxisInUse = false;
        }

        if (Input.GetButtonDown("A"))
        {
            
            var testActive = false;
            for (int i = 0; i < SelectedPlayers.Length; i++)
            {
                if (!SelectedPlayers[i].activeInHierarchy && !testActive)
                {
                    print("oui");
                    testActive = true;
                    
                    SelectedPlayers[i].GetComponent<Image>().sprite = Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.CharacterSprite;
                    SelectedPlayers[i].transform.GetChild(0).GetComponent<Text>().text = Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.Name;
                    SelectedPlayers[i].SetActive(true);
                }
            }
        }
    }
}
