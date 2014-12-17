using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleSceneManager : SceneManager
{

		public Text StatusText;
		public Button PlayButton;
		public Text PlayButtonText;
		
		public void Awake ()
		{
				if (this != Instance) {
						Destroy (this.gameObject);
						return;
				}
		}

		// Use this for initialization
		void Start ()
		{
		}
		
		private bool CanStart {
				get {
						return PhotonNetwork.room.playerCount == 2;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (PhotonNetwork.inRoom) {
				
						if (this.CanStart) {
								this.StatusText.text = "開始できます";
								this.PlayButton.gameObject.SetActive (false);
								PhotonNetwork.LoadLevel ("Main");
						} else {
								this.StatusText.text = "対戦相手を検索中…";
								this.PlayButtonText.text = "キャンセル";
								this.PlayButton.gameObject.SetActive (true);
						}
				
				} else if (PhotonNetwork.insideLobby) {
						this.StatusText.text = "サーバー接続完了";
						this.PlayButtonText.text = "プレイ";
						this.PlayButton.gameObject.SetActive (true);
				} else {
						this.StatusText.text = "サーバー接続中…";
						this.PlayButtonText.text = "プレイ";
						this.PlayButton.gameObject.SetActive (false);
				}	
		}
		
		public	void OnButtonClick ()
		{
				if (PhotonNetwork.inRoom) {
				
						Debug.Log ("master : " + PhotonNetwork.isMasterClient);
					
				
						PhotonNetwork.LeaveRoom ();
				} else {
						PhotonNetwork.JoinRandomRoom ();
				}
		}
	
		void OnPhotonRandomJoinFailed ()
		{
				PhotonNetwork.CreateRoom (null, true, true, 2);
		}
	
		void OnJoinedRoom ()
		{
				Debug.Log ("JonnedRoom");
		}
		
		void OnPhotonPlayerConnected (PhotonPlayer newPlayer)
		{
				Debug.Log ("Player Connected : " + newPlayer);
		}
		
		
}

