using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviour
{
	public void OnClickRoom()
	{
		Transform childTransform = transform.Find("RoomNameTxt");

		// 버튼의 자식 객체로부터 Text 컴포넌트 가져오기
		Text buttonText = childTransform.gameObject.GetComponentInChildren<Text>();

		// Text 컴포넌트가 있는지 확인
		if (buttonText != null)
		{
			// Text 컴포넌트의 텍스트 내용 가져오기
			string textContent = buttonText.text;

			GameObject.Find("LobbyManager").GetComponent<LobbyManager>().CurRoomName = textContent;
		}
		else
		{
			Debug.LogWarning("버튼의 자식으로 Text 컴포넌트를 찾을 수 없습니다.");
		}
	}
}
