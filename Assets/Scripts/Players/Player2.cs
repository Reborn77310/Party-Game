using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    private ChampionSelectManager championSelect;
    private int playerNumber = 1;

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
        if (!championSelect.PlayerJoined[playerNumber] && GamePad.GetButton(CButton.Start, PlayerIndex.Two))
        {
            championSelect.PlayerJoined[playerNumber] = true;
            SelectionSquare.SetActive(true);
            print("PlayerTwo joined");
        }

        var horizontal = GamePad.GetAxis(CAxis.LX, PlayerIndex.Two);
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
            var yPosition = SelectionSquare.transform.position.y;
            SelectionSquare.transform.position = new Vector3(championSelect.Players[actualPlayerSelected].transform.position.x, yPosition, championSelect.Players[actualPlayerSelected].transform.position.z);
        }
        else if (leftAxisInUse)
        {
            leftAxisInUse = false;
        }

        if (GamePad.GetButton(CButton.A, PlayerIndex.Two) && !playerValider && SelectionSquare.activeInHierarchy)
        {
            if (!championSelect.SelectedPlayers[playerNumber].activeInHierarchy &&
                !championSelect.isPlayerSelected[actualPlayerSelected])
            {
                GameMaster.PlayerTwo = actualPlayerSelected;
                championSelect.isPlayerSelected[actualPlayerSelected] = true;
                championSelect.SelectedPlayers[playerNumber].SetActive(true);

                selectedPlayers[playerNumber].GetComponent<Image>().sprite = championSelect.Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.CharacterSprite;
                selectedPlayers[playerNumber].transform.GetChild(0).GetComponent<Text>().text = championSelect.Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.Name;
                selectedPlayers[playerNumber].SetActive(true);

                playerSelectedNumber = actualPlayerSelected;
                championSelect.Players[playerSelectedNumber].GetComponent<CharacterInfo>().usedImage.SetActive(true);

                playerValider = true;
                SelectionSquare.SetActive(false);
            }
        }

        if (GamePad.GetButton(CButton.B, PlayerIndex.Two))
        {
            if (championSelect.SelectedPlayers[playerNumber].activeInHierarchy && playerValider && !SelectionSquare.activeInHierarchy)
            {
                GameMaster.PlayerTwo = -1;
                championSelect.isPlayerSelected[playerSelectedNumber] = false;
                championSelect.SelectedPlayers[playerNumber].SetActive(false);
                championSelect.Players[playerSelectedNumber].GetComponent<CharacterInfo>().usedImage.SetActive(false);
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
