using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainSceneManager : SceneManager
{	
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
//				Invoke ("CreateTank", 3.0f);
				CreateTank ();
		}
	
	
		public void ButtonClicked ()
		{
				PhotonNetwork.isMessageQueueRunning = true;
		}
	
		private void CreateTank ()
		{
				Vector3 pos;
				Quaternion quo;
				if (PhotonNetwork.isMasterClient) {
						pos = new Vector3 (90, 1, 0);
						quo = Quaternion.AngleAxis (-90, new Vector3 (0, 1, 0));
				} else {
						pos = new Vector3 (-90, 1, 0);
						quo = Quaternion.AngleAxis (90, new Vector3 (0, 1, 0));
				}
				GameObject go = PhotonNetwork.Instantiate ("Tank", pos, quo, 0);
				Tank t = go.GetComponent<Tank> ();

				FollowCamera c = go.AddComponent<FollowCamera> ();
				c.camera = Camera.main;
				if (PhotonNetwork.isMasterClient) {
						c.OffsetPosition = new Vector3 (4, 3, 0);
				} else {
						c.OffsetPosition = new Vector3 (-4, 3, 0);
				}
				c.OffsetAngle = Quaternion.AngleAxis (0, Vector3.up);
		}
		
	
		/// <summary>
		/// リモートプレイヤーが部屋を抜けた際に呼び出されます。
		/// 退室したプレイヤーは既に PhotonNetwork.playerList から除外されています。
		/// </summary>
		/// <remarks>
		/// あなたのクライアントが PhotonNetwork.leaveRoom を呼び出した場合、
		/// PUNは残ったクライアント上でこのメソッドを呼び出します。
		/// リモートクライアントの接続が切れると、
		/// 数秒後のタイムアウトの後、このコールバックが呼び出されます。
		/// </remarks>
		void OnPhotonPlayerDisconnected (PhotonPlayer otherPlayer)
		{
				Debug.Log (otherPlayer.name + "が部屋を抜けました。");
				PhotonNetwork.LeaveRoom ();
				PhotonNetwork.LoadLevel ("Title");
		}
		
		public void Quit ()
		{
				PhotonNetwork.LeaveRoom ();
				PhotonNetwork.LoadLevel ("Title");
		}
}

