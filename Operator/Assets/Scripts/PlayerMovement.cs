using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float speed = 6.0f;
	[SerializeField] float jumpSpeed = 8.0f;

	[SerializeField] float sensitivityX = 15F;
	[SerializeField] float sensitivityY = 15F;
	[SerializeField] float minimumY = -60F;
	[SerializeField] float maximumY = 60F;
	float rotationX = 0F;
	float rotationY = 0F;

	[SerializeField] Camera camera;
	[SerializeField] Rigidbody rigidbody;

	Vector3 moveDirection = Vector3.zero;

	void Update() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized * speed;

		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = ClampAngle(rotationY, minimumY, maximumY);
		camera.transform.localRotation = Quaternion.AngleAxis(rotationY, -Vector3.right);
		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);

		//if (characterController.isGrounded) {
		//	if (Input.GetButton("Jump"))
		//		moveDirection.y = jumpSpeed;
		//}
	}

	void FixedUpdate() {
		transform.Translate(moveDirection * Time.deltaTime);
	}

	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360F)
         angle += 360F;
		if (angle > 360F)
         angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}
