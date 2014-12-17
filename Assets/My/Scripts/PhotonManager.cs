using UnityEngine;
using System.Collections;

public class PhotonManager : SingletonMonoBehaviour<PhotonManager>
{
		public void Awake ()
		{
				if (this != Instance) {
						Destroy (this.gameObject);
						return;
				}
		
				DontDestroyOnLoad (this.gameObject);
		}
		
		void Start ()
		{
				PhotonNetwork.ConnectUsingSettings ("0.1");
		}
		
		void OnGUI ()
		{
				GUI.Label (new Rect (10, 2, 200, 24), PhotonNetwork.connectionStateDetailed.ToString ());
		}
	
		void OnJoinedLobby ()
		{
				Debug.Log ("OnJoinedLobby");
		}
	
		void OnPhotonRandomJoinFailed ()
		{
				Debug.Log ("OnPhotonRandomJoinFailed");
		}
	
		void OnJoinedRoom ()
		{
				Debug.Log ("OnJoinedRoom RoomName:" + PhotonNetwork.room.name); 	
		}
		
	
}