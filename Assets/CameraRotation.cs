using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{
    Transform target;
    float preDegree = 0;
    float preY = 0;

    Slider cameraRotationSlider;
    Slider cameraPositionSlider;
    Vector3 ogCameraPosition;
    void Start()
    {
        target = gameObject.GetComponentInChildren<Transform>();

        cameraRotationSlider = GameObject.Find("RotateCamera").GetComponent<Slider>();

        cameraPositionSlider = GameObject.Find("MoveCamera").GetComponent<Slider>();

        ogCameraPosition = transform.position;
    }

    public void RotateCamera(){
        transform.RotateAround(target.position, transform.right, ((cameraRotationSlider.value > 0 && cameraRotationSlider.value > preDegree) || (cameraRotationSlider.value < 0 && cameraRotationSlider.value > preDegree)) ? 0.9f : -0.9f);
        preDegree = cameraRotationSlider.value;
    }

    public void MoveCamera(){
        float addToY = ((cameraPositionSlider.value > 0 && cameraPositionSlider.value > preY) || (cameraPositionSlider.value < 0 && cameraPositionSlider.value > preY)) ? 0.1f : -0.1f;
        transform.position = new Vector3(transform.position.x,transform.position.y + addToY, transform.position.z);
        preY = cameraPositionSlider.value;
    }

    public void ResetCamera(){
        transform.position = ogCameraPosition;
        this.transform.rotation = Quaternion.identity;
        StartCoroutine(WaitResetRotation());

        cameraPositionSlider.value = 0;
        cameraRotationSlider.value = 0;
    }

    private IEnumerator WaitResetRotation(){
        yield return new WaitForSeconds(0.001f);

        this.transform.rotation = Quaternion.identity;
    }
}
