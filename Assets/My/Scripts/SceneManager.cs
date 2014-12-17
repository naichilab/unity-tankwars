using UnityEngine;
using System.Collections;

/// <summary>
/// シーンを制御するためのクラス
/// </summary>
public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
		public void Awake ()
		{
		
				if (this != Instance) {
						Destroy (this.gameObject);
						return;
				}
		}
}