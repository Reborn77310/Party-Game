using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    private ChampionSelectManager championSelect;
    private int playerNumber = 0;

    private int actualPlayerSelected = 0;
    private int playerSelectedNumber = 0;

    private bool leftAxisInUse = false;
    private bool playerValider = false;

    GameObject[] selectedPlayers = new GameObject[4];
    public GameObject SelectionSquare;

    void Awake()
    {
        championSelect = GameObject.Find("GameMaster").GetComponent<ChampionSelectManager>();
        selectedPlayers = championSelect.SelectedPlayers;
    }

    void Update()
    {
        if (!championSelect.PlayerJoined[playerNumber] && GamePad.GetButton(CButton.Start, PlayerIndex.One))
        {
            championSelect.PlayerJoined[playerNumber] = true;
            SelectionSquare.SetActive(true);
            print("PlayerOne joined");
        }

        var horizontal = GamePad.GetAxis(CAxis.LX, PlayerIndex.One);
        if (Mathf.Abs(horizontal) > 0.2f && SelectionSquare.activeInHierarchy)
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
            SelectionSquare.transform.position = championSelect.Players[actualPlayerSelected].transform.position;
        }
        else if (leftAxisInUse)
        {
            leftAxisInUse = false;
        }

        if (GamePad.GetButton(CButton.A, PlayerIndex.One) && !playerValider && SelectionSquare.activeInHierarchy)
        {
            if (!championSelect.SelectedPlayers[playerNumber].activeInHierarchy &&
                !championSelect.isPlayerSelected[actualPlayerSelected])
            {
                championSelect.isPlayerSelected[actualPlayerSelected] = true;
                championSelect.SelectedPlayers[playerNumber].SetActive(true);

                selectedPlayers[playerNumber].GetComponent<Image>().sprite = championSelect.Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.CharacterSprite;
                selectedPlayers[playerNumber].transform.GetChild(0).GetComponent<Text>().text = championSelect.Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.Name;
                selectedPlayers[playerNumber].SetActive(true);

                playerSelectedNumber = actualPlayerSelected;
                playerValider = true;
                SelectionSquare.SetActive(false);
            }
        }

        if (GamePad.GetButton(CButton.B, PlayerIndex.One))
        {
            if (championSelect.SelectedPlayers[playerNumber].activeInHierarchy && playerValider && !SelectionSquare.activeInHierarchy)
            {
                championSelect.isPlayerSelected[playerSelectedNumber] = false;
                championSelect.SelectedPlayers[playerNumber].SetActive(false);
                playerValider = false;
                SelectionSquare.SetActive(true);
            }
            /*else if (SelectionSquare.activeInHierarchy)
            {
                championSelect.PlayerJoined[playerNumber] = false;
                SelectionSquare.SetActive(false);
            }*/
        }
    }
}
