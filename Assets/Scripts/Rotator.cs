using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public GameObject RotatorAngle;
    public float RotationSpeed;
    public bool leftispressed;
    public bool rightispressed;

    public void RotateLeft ()
    {
        RotatorAngle.transform.Rotate(Vector3.down * Time.deltaTime * RotationSpeed);

    }

    public void RotateRight()
    {
        RotatorAngle.transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
    }

    public void Update()
    {
        if(leftispressed == true)
        {
            RotateLeft();
        }
        else if(rightispressed == true)
        {
            RotateRight();
        }
    }

    public void leftPress() { leftispressed = true; }
    public void leftUp() { leftispressed = false; }
    public void rightPress() { rightispressed = true; }
    public void rightUp() { rightispressed = false; }

}
