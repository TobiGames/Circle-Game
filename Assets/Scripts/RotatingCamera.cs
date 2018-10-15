using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour {

    public Camera MainCamera;
    public float RotationSpeed;

    // Update is called once per frame
    void Update () {
        MainCamera.transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
    }
}
