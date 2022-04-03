using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager2 : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    public RoomItem roomItemPrefab;
     List<RoomItem> roomItemList = new List<RoomItem>();
     public Transform contentObject;
     public float timeBetweenUpdates=1.5f;
     float nextUpdateTime;

     public List<PlayerItem> playerItemsList = new List<PlayerItem>();
     public PlayerItem playerItemPrefab;
     public Transform playerItemParent;
     public GameObject playButton;

     
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime){

        UpdateRoomList(roomList);
        nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }
    void UpdateRoomList(List<RoomInfo>list){
        foreach(RoomItem item in roomItemList){
            Destroy(item.gameObject);
        }
        roomItemList.Clear();
        foreach(RoomInfo room in list){
            RoomItem newRoom = Instantiate(roomItemPrefab,contentObject);
            newRoom.setRoomName(room.Name);
            roomItemList.Add(newRoom);

        }
    } 

    void Start()
    {
        PhotonNetwork.JoinLobby();

    }
    public void onClickCreate(){
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = 2, BroadcastPropsChangeToAll=true});
        }
    
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        roomPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        roomName.text = "Room Name: "+ PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }
    public void JoinRoom (string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }
    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true); 
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    void UpdatePlayerList(){
        foreach(PlayerItem item in playerItemsList){
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();
        if(PhotonNetwork.CurrentRoom== null){
            return;
        }
        foreach (KeyValuePair<int,Player> Player in PhotonNetwork.CurrentRoom.Players){
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab,playerItemParent);
            newPlayerItem.SetPlayerInfo(Player.Value);
            playerItemsList.Add(newPlayerItem);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {        
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
    public void Update(){
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount>=2){
           playButton.SetActive(true); 
        }else{
            playButton.SetActive(false);
        }
    }
    public void OnClickPlayButton(){
        
        // PhotonNetwork.CurrentRoom.IsOpen = false;
        // PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("Level4_AI");

    }
    
    
}
