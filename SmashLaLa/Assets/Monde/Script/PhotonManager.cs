using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    //public PersonnageCreation personnageCreation;
    //[SerializeField] public List<string> nomPrefab = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Debug.Log("ECHAPE");
        {
            if (GameIsPaused)
            {
                Debug.Log("Dans le if");
                Resume();
            }

            else
            {
                Debug.Log("Dans le else");
                Pause();
            }
        }
    }

    //connection au lobby de jeu
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        //string nomPersonnage = string.Join(",", nomPrefab);
        //PhotonNetwork.Instantiate(nomPersonnage, new Vector2(Random.Range(-8f, 8f), transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate("Lapin", new Vector2(Random.Range(-8f, 8f), transform.position.y), Quaternion.identity);
    }


    void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    void Pause()
    {
        Debug.Log("je suis dans pause()");
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
