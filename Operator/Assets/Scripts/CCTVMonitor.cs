using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVMonitor : MonoBehaviour
{
    [SerializeField] Camera camera;

    public void Activate()
    {
        StartCoroutine(ActiveRoutine());
    }

    IEnumerator ActiveRoutine()
    {
        RenderTexture prevTexture = camera.targetTexture;
        camera.targetTexture = null;
        GameManager.instance.cameraTipText.gameObject.SetActive(true);
        yield return null;


        while (true)
        {
            if (Input.GetKeyDown(KeyCode.F))
                break;

            if (Input.GetKey(KeyCode.A))
            {
                camera.transform.localRotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles + new Vector3(0, -30 * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                camera.transform.localRotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles + new Vector3(0, 30 * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.W))
            {
                camera.transform.localRotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles + new Vector3(-30 * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                camera.transform.localRotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles + new Vector3(30 * Time.deltaTime, 0));
            }


            yield return null;
        }

        yield return null;
        camera.targetTexture = prevTexture;
        GameManager.instance.cameraTipText.gameObject.SetActive(false);
        GameManager.instance.playerMovement.ReturnFromCCTV();
    }
}
