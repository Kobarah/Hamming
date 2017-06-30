using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{

	public float xMin, xMax, zMin, zMax;

}


public class MovimentoNavicella : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public Rigidbody rb;
	public float zPos = 20f;

	
	// Update is called once per frame
	void FixedUpdate () 
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (-moveHorizontal, 0.0f, -moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.zMax),
			zPos,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		//transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,10)*Time.deltaTime*5);
		//transform.Rotate(0,0,speed*Time.deltaTime,Space.Self);
			

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);


	}
}


