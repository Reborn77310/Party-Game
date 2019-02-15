using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChampionSelectManager : MonoBehaviour
{
    public int NumberOfPlayers;
    private static GameObject[] Players;


    public bool[] isPlayerSelected;
    public GameObject[] SelectedPlayers;
    public GameObject SelectionSquare;
    [SerializeField] private int actualPlayerSelected = 0;

    private bool leftAxisInUse = false;

    void Awake()
    {
        Players = new GameObject[NumberOfPlayers];
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            Players[i] = GameObject.Find("Perso" + i);
        }
        isPlayerSelected = new bool[Players.Length];
    }

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
                if (!SelectedPlayers[i].activeInHierarchy && !testActive && !isPlayerSelected[actualPlayerSelected])
                {
                    testActive = true;
                    isPlayerSelected[actualPlayerSelected] = true;
                    Players[actualPlayerSelected].GetComponent<CharacterInfo>().usedImage.SetActive(true);

                    SelectedPlayers[i].GetComponent<Image>().sprite = Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.CharacterSprite;
                    SelectedPlayers[i].transform.GetChild(0).GetComponent<Text>().text = Players[actualPlayerSelected].GetComponent<CharacterInfo>().character.Name;
                    SelectedPlayers[i].SetActive(true);
                }
            }
        }

        if (Input.GetButtonDown("B"))
        {
            for (int i = 0; i < isPlayerSelected.Length; i++)
            {
                if (isPlayerSelected[i])
                {
                    Players[i].GetComponent<CharacterInfo>().usedImage.SetActive(false);
                    isPlayerSelected[i] = false;
                }
            }

            for (int i = 0; i < SelectedPlayers.Length; i++)
            {
                SelectedPlayers[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameMaster.OnChampionSelect = false;
            var nombre = 0;
            for (int i = 0; i < isPlayerSelected.Length; i++)
            {
                if (isPlayerSelected[i] && nombre == 0)
                {
                    GameMaster.PlayerOne = i;
                    nombre++;
                }
                else if (isPlayerSelected[i] && nombre == 1)
                {
                    GameMaster.PlayerTwo = i;
                    nombre++;
                }
                else if (isPlayerSelected[i] && nombre == 2)
                {
                    GameMaster.PlayerThree = i;
                    nombre++;
                }
                else if (isPlayerSelected[i] && nombre == 3)
                {
                    GameMaster.PlayerFour = i;
                    nombre++;
                }

            }
            SceneManager.LoadScene("SampleScene");
        }

    }
}
