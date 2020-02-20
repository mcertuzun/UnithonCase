using System.Collections;
using UnityEngine;

namespace Utils
{
	public class AutoDestroy : MonoBehaviour 
	{
		public void Start ()
		{
			StartCoroutine(WaitAndDestroy());
		}

		private IEnumerator WaitAndDestroy()
		{
			yield return new WaitForSeconds(2F);
			Destroy(gameObject);
		}	
	}
}
