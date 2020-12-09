using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class LunchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject ConnectingPanel;
    [SerializeField] private GameObject EnterPanel;
    [SerializeField] private GameObject JoinRoomPanel;
    [SerializeField] private GameObject JoinedRoomPanel;

    private void Awake()
    {
        // load sync scene 
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // connect to photon with configured server settings 
        //PhotonNetwork.ConnectUsingSettings();
    }

    public void EnterGame()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            EnterPanel.SetActive(false);
            ConnectingPanel.SetActive(true);
        }
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #region Callback
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        // enable lobby 
        // disable connecting ...
        print( "connected  to the master server " + PhotonNetwork.NickName);
        ConnectingPanel.SetActive(false);
        JoinRoomPanel.SetActive(true);
    }

    public override void OnConnected()
    {
        base.OnConnected();
        print("connected to the internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("random room join failed, creating a new room");
        JoinRoomPanel.SetActive(false);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("joined on :" + PhotonNetwork.CurrentRoom.Name);
        
        JoinRoomPanel.SetActive(false);
        JoinedRoomPanel.SetActive(true);
        
        //load game scene for all the clients 
        // wait till other player join
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("created a lobby :"+PhotonNetwork.CurrentLobby.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print("Player joined  on : "+PhotonNetwork.CurrentRoom.Name + " Total Player "+PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

    #region private methods

    void CreateAndJoinRoom()
    {
        string roomName = "Room"+ Random.Range(1, 9999).ToString();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    #endregion
}
