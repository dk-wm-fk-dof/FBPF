using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectScript : MonoBehaviour
{
	public float ResetPosition;
	public float OffScreen;

	void Update ()
	{
		this.transform.Translate( -Vector3.right * 3 * Time.deltaTime );
		
		if(this.transform.position.x<OffScreen)
		{
			this.transform.position += new Vector3( (ResetPosition * 1.5f), 0, 0 );
		}	
	}
}
