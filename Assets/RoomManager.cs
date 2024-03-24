using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{


	private void Start()
	{
		int playerCount = 1;
		foreach (var player in PhotonNetwork.CurrentRoom.Players)
		{
			var gameObject = GameObject.Find("Player_" + playerCount);
			var playerName = gameObject.GetComponent<Text>();
			playerName.text = player.Value.NickName;
			playerCount += 1;
		}


	}
	public override void OnLeftRoom()
	{
		SceneManager.LoadScene("EntryScene");
	}

	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}

	public override void OnPlayerEnteredRoom(Player other)
	{

		Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

		var room = PhotonNetwork.CurrentRoom;

		if (PhotonNetwork.IsMasterClient)
		{
			Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

			//LoadArena();
		}

		int playerCount = 1;
		foreach (var player in PhotonNetwork.CurrentRoom.Players)
		{
			var gameObject = GameObject.Find("Player_" + playerCount);
			var playerName = gameObject.GetComponent<Text>();
			playerName.text = player.Value.NickName;
			playerCount += 1;
		}
	}

	public override void OnPlayerLeftRoom(Player other)
	{
		Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

		if (PhotonNetwork.IsMasterClient)
		{
			Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

			//LoadArena();
		}
	}
}
