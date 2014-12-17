using UnityEngine;
using System.Collections;

public class ExplodeEffect : Photon.MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				if (photonView.isMine) {
						Invoke ("des", 3.0f);
				}
		}
		
		void des ()
		{
				PhotonNetwork.Destroy (this.gameObject);
		}
	
}
