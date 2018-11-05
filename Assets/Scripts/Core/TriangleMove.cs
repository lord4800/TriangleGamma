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
        float r = 1;
        float x = r * Mathf.Cos(Mathf.Deg2Rad * angle);
        float y = r * Mathf.Sin(Mathf.Deg2Rad * angle);
        Vector3 lookAt = new Vector3(x, y, 0);
        lookRot = Quaternion.LookRotation(transform.forward, lookAt);
    }

    void DragInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            float y = Input.mousePosition.y - Screen.height / 2;
            float x = Input.mousePosition.x - Screen.width / 2;
            float cosA = x / Mathf.Sqrt(x * x + y * y);
            dragAngle = Mathf.Acos(cosA);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //set angle change;
            float y = Input.mousePosition.y - Screen.height / 2;
            float x = Input.mousePosition.x - Screen.width / 2;
            float cosA = x / Mathf.Sqrt(x * x + y * y);
            float newAngle;
            if (y > 0)

                newAngle = Mathf.Acos(cosA);
            else
                newAngle = - Mathf.Acos(cosA);
            float deltaAngle = newAngle  - dragAngle;
            dragAngle = newAngle;
            Debug.Log(Mathf.Rad2Deg * dragAngle);
            float angleWithDelta = Mathf.Deg2Rad * angle + deltaAngle;
            angle = Mathf.Rad2Deg * angleWithDelta;
            // create vector in eulerXY
            float r = 1;
            x = r * Mathf.Cos(angleWithDelta);
            y = r * Mathf.Sin(angleWithDelta);
            Vector3 lookAt = new Vector3(x, y, 0);
            lookRot = Quaternion.LookRotation(transform.forward, lookAt);
        }
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
            float r = 1;
            float x = r * Mathf.Cos(Mathf.Deg2Rad * angle);
            float y = r * Mathf.Sin(Mathf.Deg2Rad * angle);
            Vector3 lookAt = new Vector3(x,y,0);
            lookRot = Quaternion.LookRotation(transform.forward, lookAt);

        }
    }
}
