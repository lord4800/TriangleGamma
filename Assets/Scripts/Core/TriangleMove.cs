using UnityEngine;

public class TriangleMove : MonoBehaviour {
    public float rotateSpeed;
    public float lerpIndex;
    public enum RotateType { side, drag, buttons }
    public RotateType rotateType = RotateType.side;

    private Quaternion lookRot = Quaternion.identity;
    private float angle = 0;
    private float dragAngle = 0;
    private bool chousedInput = false;
    private bool draging = false;

    void Update() {
        if (chousedInput)
        {
            switch (rotateType)
            {
                case RotateType.side: { SideInput(); break; }
                case RotateType.drag: { DragInput(); break; }
                case RotateType.buttons: { ButtonsInput(); break; }
            }
        }
        else
        {
            DragInput();
            if (!draging)
                SideInput();
#if UNITY_EDITOR
            ButtonsInput();
#endif
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, lerpIndex) ;
    }

    void SideInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.mousePosition.x - Screen.width / 2 < 0)
            {
                angle += rotateSpeed * Time.smoothDeltaTime;
            }
            else
            {
                angle -= rotateSpeed * Time.smoothDeltaTime;
            }
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

        float angleWithDelta = Mathf.Deg2Rad * angle + deltaAngle;
        angle = Mathf.Rad2Deg * angleWithDelta;
        lookRot = Quaternion.LookRotation(transform.forward, GetLookAtVec());
    }

    private void DragInput()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.mousePosition.x > Screen.width / 2 - Screen.width / 6 && Input.mousePosition.x < Screen.width / 2 + Screen.width / 6)
            {
                draging = true;
                StartDrag();
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && draging)
        {
            OnDrag();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && draging)
        {
            draging = false;
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
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                angle -= rotateSpeed * Time.smoothDeltaTime;
            }
            if (Input.mousePosition.x < Screen.width / 2)
            {
                angle += rotateSpeed * Time.smoothDeltaTime;
            }
            lookRot = Quaternion.LookRotation(transform.forward, GetLookAtVec());
        }
        */
    }
}
