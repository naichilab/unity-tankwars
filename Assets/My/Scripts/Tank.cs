using UnityEngine;
using System.Collections;

public class Tank : Photon.MonoBehaviour
{
		private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
		private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this
	

		Cannon cannon;

		void Awake ()
		{
				if (photonView.isMine) {
						rigidbody.isKinematic = false;
				}
		}
	
		// Use this for initialization
		void Start ()
		{
				if (photonView.isMine) {
						Debug.Log ("Tank.Start");
						this.cannon = this.gameObject.GetComponentInChildren<Cannon> ();
//						this.gameObject.AddComponent<FollowCamera> ().AttachCamera (Camera.main);
				}
		}
		
		
	
		// Update is called once per frame
		void Update ()
		{
				if (photonView.isMine) {

						if (Input.GetKey (KeyCode.RightArrow)) {
								this.transform.position = new Vector3 (this.transform.position.x + 0.1f
				                                       , this.transform.position.y
				                                       , this.transform.position.z);
						} else if (Input.GetKey (KeyCode.LeftArrow)) {
								this.transform.position = new Vector3 (this.transform.position.x - 0.1f
				                                       , this.transform.position.y
				                                       , this.transform.position.z);
						}
			
						if (Input.GetKey (KeyCode.UpArrow)) {
								if (PhotonNetwork.isMasterClient) {
										this.cannon.Rotate (1.0f);
								} else {
										this.cannon.Rotate (-1.0f);
								}
						} else if (Input.GetKey (KeyCode.DownArrow)) {
								if (PhotonNetwork.isMasterClient) {
										this.cannon.Rotate (-1.0f);
								} else {
										this.cannon.Rotate (1.0f);
								}
						}
			
						if (Input.GetKeyDown (KeyCode.Space)) {
								this.cannon.Shot ();
						}
				} else {
						transform.position = Vector3.Lerp (transform.position, this.correctPlayerPos, Time.deltaTime * 5);
						transform.rotation = Quaternion.Lerp (transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
				}
		
		}
		
		void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
		{
				if (stream.isWriting) {
						stream.SendNext (transform.position);
						stream.SendNext (transform.rotation);
				} else {
						this.correctPlayerPos = (Vector3)stream.ReceiveNext ();
						this.correctPlayerRot = (Quaternion)stream.ReceiveNext ();
				}
		}
	
}

