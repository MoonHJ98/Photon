using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
	public void UpdateRooms(List<RoomInfo> roomList)
	{
		foreach(RoomInfo room in roomList) 
		{
			GameObject lobbyContent = GameObject.Find("LobbyContent");

			if (lobbyContent == null)
			{
				Debug.LogError("lobbyContent GameObject not found.");
				return;
			}
			GameObject instance = Instantiate(Resources.Load("RoomForLobby", typeof(GameObject)), lobbyContent.transform) as GameObject;

			// 버튼의 자식 오브젝트인 Text 컴포넌트 찾기
			Text buttonText = instance.GetComponentInChildren<Text>();

			// Text 컴포넌트가 있다면 텍스트 변경
			if (buttonText != null)
			{
				buttonText.text = room.Name;
			}
			else
			{
				Debug.LogError("Text component not found in the button prefab.");
			}
		}
	}
	public string CurRoomName { get; set; } = "";
	/*
	

	void LoadRoom()
	{
		if (!PhotonNetwork.IsMasterClient)
		{
			Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
			return;
		}
		Debug.LogFormat("PhotonNetwork : " + PhotonNetwork.CurrentRoom.Name);
		PhotonNetwork.LoadLevel("RoomScene");
	}

	public override void OnPlayerEnteredRoom(Player other)
	{
		Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

		if (PhotonNetwork.IsMasterClient)
		{
			Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

			LoadRoom();
		}
	}

	public override void OnPlayerLeftRoom(Player other)
	{
		Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

		if (PhotonNetwork.IsMasterClient)
		{
			Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

			LoadRoom();
		}
	}
	/// <summary>
	/// Called when the local player left the room. We need to load the launcher scene.
	/// </summary>
	public override void OnLeftRoom()
	{
		SceneManager.LoadScene(0);
	}


	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}
	*/
}
