using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class MultiplayerLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text m_NotifText;
  
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #region Public Methods

    public void EnterGame()
    {
        if (!PhotonNetwork.IsConnected)
        {
            m_NotifText.text = "entering game ...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void StartGame()
    {
        
    }

    #endregion

    #region Photon CallBack

    public override void OnConnectedToMaster()
    {
        m_NotifText.text = "connected to master";
        print("connected to master");
        JoinRoom();
    }

    public override void OnConnected()
    {
        m_NotifText.text = "connected to the internet";
        print("no internet");
    }

    public override void OnJoinedLobby()
    {
        m_NotifText.text = "joined lobby";
        print("joined lobby");
    }

    public override void OnJoinedRoom()
    {
        m_NotifText.text = "joined room ";

        StartGame();
        print("joined room");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        m_NotifText.text = "random room join failed, creating new room ...";
        CreateAndJoinRoom();
    }

    #endregion
    
    void CreateAndJoinRoom()
    {
        string roomName = "Room"+ Random.Range(1, 9999).ToString();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
   
}
