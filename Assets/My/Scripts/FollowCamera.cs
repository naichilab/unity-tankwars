using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
		public Camera camera;
		public Vector3 OffsetPosition;
		public Quaternion OffsetAngle;

		void Update ()
		{
				if (this.camera == null)
						return;
						
				this.camera.transform.position = this.transform.position + this.OffsetPosition;
				this.camera.transform.rotation = this.transform.rotation * this.OffsetAngle;
		}
}
