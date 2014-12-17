using UnityEngine;

public class MyRandomMatch : Photon.MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
				PhotonNetwork.ConnectUsingSettings ("0.1");
		}
	
		void OnJoinedLobby ()
		{
				Debug.Log ("OnJoinedLobby");
				PhotonNetwork.JoinRandomRoom ();
		}
	
		void OnPhotonRandomJoinFailed ()
		{
				Debug.Log ("OnPhotonRandomJoinFailed");
				PhotonNetwork.CreateRoom (null);
		}
	
		void OnJoinedRoom ()
		{
				Debug.Log ("OnJoinedRoom");
				GameObject tank = PhotonNetwork.Instantiate ("Tank", new Vector3 (-150, 1, 0), Quaternion.identity, 0);
		}
	
		void OnGUI ()
		{
				GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		
		}
}
