using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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
	[SerializeField] TextMeshProUGUI tipText;

	Vector3 moveDirection = Vector3.zero;
    CCTVMonitor controllerCamera;

    void Awake(){
        rotationX = transform.localRotation.eulerAngles.x;
        rotationY = camera.transform.localRotation.eulerAngles.y;
    }

    void Update() {
        if (controllerCamera)
            return;

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized * speed;

		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = ClampAngle(rotationY, minimumY, maximumY);
		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		camera.transform.localRotation = Quaternion.AngleAxis(rotationY, -Vector3.right);

        //if (characterController.isGrounded) {
        //	if (Input.GetButton("Jump"))
        //		moveDirection.y = jumpSpeed;
        //}

        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.0f, LayerMask.GetMask("CCTVMonitor"))) {
            tipText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) {
                controllerCamera = hit.transform.gameObject.GetComponent<CCTVMonitor>();
                controllerCamera.Activate();
                camera.gameObject.SetActive(false);
                tipText.gameObject.SetActive(false);
            }
        }
        else {
            tipText.gameObject.SetActive(false);
        }
    }

	void FixedUpdate() {
		transform.Translate(moveDirection * Time.deltaTime);
	}

    public void ReturnFromCCTV()
    {
        controllerCamera = null;
        camera.gameObject.SetActive(true);
    }

    public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360F)
         angle += 360F;
		if (angle > 360F)
         angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}
