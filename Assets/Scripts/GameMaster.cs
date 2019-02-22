using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static int PlayerOne = -1;
    public static int PlayerTwo = -1;
    public static int PlayerThree = -1;
    public static int PlayerFour = -1;

    public static bool OnChampionSelect = true;
    public List<GameObject> Players;
    public GameObject[] PlayersActives = new GameObject[4];

    public int NumberOfPlayers = 0;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!OnChampionSelect)
        {
            foreach (Transform child in GameObject.Find("Personnages").transform)
            {
                Players.Add(child.gameObject);
            }

            if (PlayerOne >= 0)
            {
                PlayersActives[0] = Players[PlayerOne];
            }

            if (PlayerTwo >= 0)
            {
                PlayersActives[1] = Players[PlayerTwo];
            }

            if (PlayerThree >= 0)
            {
                PlayersActives[2] = Players[PlayerThree];
            }

            if (PlayerFour >= 0)
            {
                PlayersActives[3] = Players[PlayerFour];
            }

            foreach (var go in PlayersActives)
            {
                if (go != null)
                {
                    go.SetActive(true);
                }
            }

            NumberOfPlayers = GetComponent<ChampionSelectManager>().CompterLesJoueurs();

            Destroy(GetComponent<Player1>());
            Destroy(GetComponent<Player2>());
            Destroy(GetComponent<Player3>());
            Destroy(GetComponent<Player4>());
            Destroy(GetComponent<ChampionSelectManager>());
        }
    }
}
