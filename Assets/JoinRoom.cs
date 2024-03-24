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

		// ��ư�� �ڽ� ��ü�κ��� Text ������Ʈ ��������
		Text buttonText = childTransform.gameObject.GetComponentInChildren<Text>();

		// Text ������Ʈ�� �ִ��� Ȯ��
		if (buttonText != null)
		{
			// Text ������Ʈ�� �ؽ�Ʈ ���� ��������
			string textContent = buttonText.text;

			GameObject.Find("LobbyManager").GetComponent<LobbyManager>().CurRoomName = textContent;
		}
		else
		{
			Debug.LogWarning("��ư�� �ڽ����� Text ������Ʈ�� ã�� �� �����ϴ�.");
		}
	}
}
