using UnityEngine;
using System.Collections;

public class Bullet : Photon.MonoBehaviour
{
		private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
	
		void Awake ()
		{
				if (photonView.isMine) {
						rigidbody.isKinematic = false;
				}
		}
	
		void Update ()
		{
				if (!photonView.isMine) {
						transform.position = Vector3.Lerp (transform.position, this.correctPlayerPos, Time.deltaTime * 5);
				}
		}
		
		void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
		{
				if (stream.isWriting) {
						stream.SendNext (transform.position);
				} else {
						this.correctPlayerPos = (Vector3)stream.ReceiveNext ();
				}
		}
		
		void  OnCollisionEnter (Collision collision)
		{
				if (photonView.isMine) {
						Vector3 pos = new Vector3 (this.gameObject.transform.position.x
		                         , this.gameObject.transform.position.y + 4f
		                         , this.gameObject.transform.position.z);
				
						PhotonNetwork.Instantiate ("Explode", pos, Quaternion.identity, 0);
						PhotonNetwork.Destroy (this.gameObject);
				}
		}
}
