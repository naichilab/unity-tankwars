using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{

		private Transform axis;
		private Transform top;
		private GameObject bullet;

		// Use this for initialization
		void Start ()
		{
	
				this.axis = this.gameObject.transform.parent;
				this.top = this.gameObject.transform.GetChild (0);
				this.bullet = (GameObject)Resources.Load ("Bullet");
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void Rotate (float deg)
		{		
		
		
				this.transform.RotateAround (this.axis.position, new Vector3 (0, 0, 1), -deg);
		}
		
		public void Shot ()
		{
				GameObject bullet = PhotonNetwork.Instantiate ("Bullet", this.top.position, Quaternion.identity, 0);
//				GameObject bullet = (GameObject)Instantiate (this.bullet, this.top.position, Quaternion.identity);
				bullet.rigidbody.velocity = this.top.up * 50;
		}
}
