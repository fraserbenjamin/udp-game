using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 0f;  // Variable that determines the forward force
	public float sidewaysForce = 0f;  // Variable that determines the sideways force

	// We marked this as "Fixed"Update because we
	// are using it to mess with physics.
	void FixedUpdate()
	{
		if (Input.GetKey("w"))
		{
			// Add a force to the right
			rb.AddForce(0, 0, forwardForce * Time.deltaTime);
		}
		if (Input.GetKey("s"))
		{
			// Add a force to the right
			rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("a"))
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
		}
	
		PlayerData playerData = new PlayerData(ConnectionManager.instance.id, transform.position, transform.rotation);
		string json = JsonUtility.ToJson(playerData);

		ConnectionManager.instance.SendData(json);
	}
}
