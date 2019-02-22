using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChampionSelectManager : MonoBehaviour
{
    public int NumberOfPlayers;
    public GameObject[] Players;

    public bool[] PlayerJoined = new bool[4];
    public bool[] isPlayerSelected;
    public GameObject[] SelectedPlayers;
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
