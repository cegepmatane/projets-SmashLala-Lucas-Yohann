using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    public PersonnageCreation personnageCreation;
    [SerializeField] public List<string> nomPrefab = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

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
        string nomPersonnage = string.Join(",", nomPrefab);
        PhotonNetwork.Instantiate(nomPersonnage, new Vector2(Random.Range(-8f, 8f), transform.position.y), Quaternion.identity);
    }
    
}
