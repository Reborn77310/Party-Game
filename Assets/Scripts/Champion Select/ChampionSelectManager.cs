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
            var test = CompterLesJoueurs();
            if (test >= 2 && GameMaster.PlayerOne >= 0)
            {
                GameMaster.OnChampionSelect = false;
                SceneManager.LoadScene("SampleScene");
            }       
        }
    }

    public int CompterLesJoueurs()
    {
        var numberOfPlayers = 0;
        if (GameMaster.PlayerOne >= 0)
        {
            numberOfPlayers++;
        }

        if (GameMaster.PlayerTwo >= 0)
        {
            numberOfPlayers++;
        }

        if (GameMaster.PlayerThree >= 0)
        {
            numberOfPlayers++;
        }

        if (GameMaster.PlayerFour >= 0)
        {
            numberOfPlayers++;
        }
        return numberOfPlayers;
    }
}
