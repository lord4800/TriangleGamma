using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMove : MonoBehaviour {
    public float rotateSpeed;
	
    public enum RotateType { arrow, drag, buttons }
    public RotateType rotateType = RotateType.arrow;

    Quaternion lookRot = Quaternion.identity;
    float angle = 0;
    float dragAngle = 0;
    // Update is called once per frame
	void Update () {
        switch (rotateType)
        {
            case RotateType.arrow: { ArrowInput(); break; }
            case RotateType.drag: { DragInput(); break; }
            case RotateType.buttons: { ButtonsInput(); break; }
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 0.4f) ;
    }

    void ArrowInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle += rotateSpeed * Time.smoothDeltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= rotateSpeed * Time.smoothDeltaTime;
        }
        lookRot = Quaternion.LookRotation(transform.forward, GetLookAtVec());
    }

    Vector3 GetLookAtVec()
    {
        float r = 1;
        float x = r * Mathf.Cos(Mathf.Deg2Rad * angle);
        float y = r * Mathf.Sin(Mathf.Deg2Rad * angle);
        return new Vector3(x, y, 0);
    }

    float GetCosA()
    {
        float y = Input.mousePosition.y - Screen.height / 2;
        float x = Input.mousePosition.x - Screen.width / 2;
        return x / Mathf.Sqrt(x * x + y * y);
    }

    void StartDrag()
    {
        float cosA = GetCosA();
        float y = Input.mousePosition.y - Screen.height / 2;
        if (y > 0)
            dragAngle = Mathf.Acos(cosA);
        else
            dragAngle = - Mathf.Acos(cosA);
    }
    void OnDrag()
    {
        //set angle change;
        float newAngle;
        float cosA = GetCosA();
        float y = Input.mousePosition.y - Screen.height / 2;
        if (y > 0)
            newAngle = Mathf.Acos(cosA);
        else
            newAngle = - Mathf.Acos(cosA);
        float deltaAngle = newAngle - dragAngle;
        dragAngle = newAngle;
        Debug.Log(Mathf.Rad2Deg * dragAngle);
        float angleWithDelta = Mathf.Deg2Rad * angle + deltaAngle;
        angle = Mathf.Rad2Deg * angleWithDelta;
        // create vector in eulerXY
        lookRot = Quaternion.LookRotation(transform.forward, GetLookAtVec());
    }

    void DragInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            StartDrag();
        if (Input.GetKey(KeyCode.Mouse0))
            OnDrag();
        /* ForTouch
         * DONT DELETE
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log(Input.GetTouch(0).position);
                //deltaDragAngle = Input.GetTouch(0).position.y/ Input.GetTouch(0).position.x;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).position.x > Screen.width / 2)
                {
                    angle -= rotateSpeed * Time.smoothDeltaTime;
                }
                if (Input.GetTouch(0).position.x < Screen.width / 2)
                {
                    angle += rotateSpeed * Time.smoothDeltaTime;
                }
                float r = 1;
                float x = r * Mathf.Cos(Mathf.Deg2Rad * angle);
                float y = r * Mathf.Sin(Mathf.Deg2Rad * angle);
                Vector3 lookAt = new Vector3(x, y, 0);
                lookRot = Quaternion.LookRotation(transform.forward, lookAt);
            }
        }
        */
    }

    void ButtonsInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //set angle change;
            if (Input.mousePosition.x > Screen.width / 2)
            {
                angle -= rotateSpeed * Time.smoothDeltaTime;
            }
            if (Input.mousePosition.x < Screen.width / 2)
            {
                angle += rotateSpeed * Time.smoothDeltaTime;
            }
            // create vector in eulerXY
            lookRot = Quaternion.LookRotation(transform.forward, GetLookAtVec());
        }
    }
}
