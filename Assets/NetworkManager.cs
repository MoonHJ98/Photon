using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;
using UnityEngine.Rendering;

public class NetworkManager : MonoBehaviourPunCallbacks
{
	public Text StatusText;
	public InputField roomInput, NickNameInput;

	public List<RoomInfo> RoomInfos { get; set; } = new List<RoomInfo>();

	public GameObject matchPanel;
	public GameObject lobbyPanel;
	public GameObject lobbyManager;


	void Awake() => Screen.SetResolution(960, 540, false);

	private void Start()
	{
		if(matchPanel != null && lobbyPanel != null)
		{
			matchPanel.SetActive(true);
			lobbyPanel.SetActive(false);
		}
	}

	void Update()
	{
		//StatusText.text = PhotonNetwork.NetworkClientState.ToString();
	}
	



	public void Connect() => PhotonNetwork.ConnectUsingSettings();

	public override void OnConnectedToMaster()
	{
		print("�������ӿϷ�");
		PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
		JoinLobby();
	}



	public void Disconnect() => PhotonNetwork.Disconnect();

	public override void OnDisconnected(DisconnectCause cause) => print("�������");



	public void JoinLobby() => PhotonNetwork.JoinLobby();

	public override void OnJoinedLobby()
	{
		print("�κ����ӿϷ�");
	}



	public void CreateRoom()
	{
		PhotonNetwork.CreateRoom(PhotonNetwork.LocalPlayer.NickName + "�� ��", new RoomOptions { MaxPlayers = 4 });
	}

	public void JoinRoom()
	{

		if (lobbyManager == null || lobbyManager.GetComponent<LobbyManager>().CurRoomName == "")
			return;

		//print("�������Ϸ�");

		PhotonNetwork.JoinRoom(lobbyManager.GetComponent<LobbyManager>().CurRoomName);


		//PhotonNetwork.LoadLevel("RoomScene");
	}

	public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);

	public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

	public void LeaveRoom() => PhotonNetwork.LeaveRoom();

	public override void OnCreatedRoom()
	{
		print("�游���Ϸ�");
		PhotonNetwork.LoadLevel("RoomScene");

	}

	public override void OnJoinedRoom()
	{

		print("�������Ϸ�");
		PhotonNetwork.LoadLevel("RoomScene");
	}

	public override void OnCreateRoomFailed(short returnCode, string message) => print("�游������");

	public override void OnJoinRoomFailed(short returnCode, string message) => print("����������");

	public override void OnJoinRandomFailed(short returnCode, string message) => print("�淣����������");

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		Debug.Log("Room list updated.");

		matchPanel.SetActive(false);
		lobbyPanel.SetActive(true);

		// ������Ʈ�� �� ����Ʈ ���
		foreach (RoomInfo room in roomList)
		{
			Debug.Log("Room Name: " + room.Name + ", Player Count: " + room.PlayerCount);
		}
	
		RoomInfos = roomList;

		lobbyManager.GetComponent<LobbyManager>().UpdateRooms(RoomInfos);
	}

	[ContextMenu("����")]
	void Info()
	{
		if (PhotonNetwork.InRoom)
		{
			print("���� �� �̸� : " + PhotonNetwork.CurrentRoom.Name);
			print("���� �� �ο��� : " + PhotonNetwork.CurrentRoom.PlayerCount);
			print("���� �� �ִ��ο��� : " + PhotonNetwork.CurrentRoom.MaxPlayers);

			string playerStr = "�濡 �ִ� �÷��̾� ��� : ";
			for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
			print(playerStr);
		}
		else
		{
			print("������ �ο� �� : " + PhotonNetwork.CountOfPlayers);
			print("�� ���� : " + PhotonNetwork.CountOfRooms);
			print("��� �濡 �ִ� �ο� �� : " + PhotonNetwork.CountOfPlayersInRooms);
			print("�κ� �ִ���? : " + PhotonNetwork.InLobby);
			print("����ƴ���? : " + PhotonNetwork.IsConnected);
			
		}
	}
}
