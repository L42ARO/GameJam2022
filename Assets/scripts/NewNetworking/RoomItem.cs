using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    LobbyManager2 manager;
    private void Awake (){
        manager=FindObjectOfType<LobbyManager2>();
    }
    public void setRoomName(string _roomname){
        roomName.text=_roomname;
    }
    public void OnClickItem(){
        manager.JoinRoom(roomName.text);
    }
}
