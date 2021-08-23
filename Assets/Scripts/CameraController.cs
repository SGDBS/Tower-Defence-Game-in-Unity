using UnityEngine;

public class CameraController : MonoBehaviour {		 

	public float panSpeed = 30f;  //speed of moving camera horizontally
	public float scrollSpeed = 5f; // speed of moving closer or farther to the ground
	public float panBorderThickness = 10f;
	public float minY = 10f;
	public float maxY = 80f;

	bool doMovement = true;

	void Update () {
		//using for turning on or turning off the moving mode
		if (Input.GetKeyDown("p"))
			doMovement = !doMovement;
		if (!doMovement)
			return;

		//using for mouve the camera
		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}


		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y += -1 * scroll *1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY); //confirm that pos.y is between minY and maxY
		transform.position = pos;
	}
}
