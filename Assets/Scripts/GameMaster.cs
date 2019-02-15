using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static int PlayerOne;
    public static int PlayerTwo;
    public static int PlayerThree;
    public static int PlayerFour;

    public static bool OnChampionSelect = true;
    public List<GameObject> Players;
    public GameObject[] PlayersActives = new GameObject[4];

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
            PlayersActives[0] = Players[PlayerOne];
            PlayersActives[1] = Players[PlayerTwo];
            PlayersActives[2] = Players[PlayerThree];
            PlayersActives[3] = Players[PlayerFour];

            foreach (var go in PlayersActives)
            {
                go.SetActive(true);
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            print(OnChampionSelect);
        }
    }

}
