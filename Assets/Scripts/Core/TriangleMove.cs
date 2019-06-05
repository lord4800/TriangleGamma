using UnityEngine;

public class TriangleMove : MonoBehaviour {
    public float rotateSpeed;
    public float lerpIndex;
    public enum RotateType { side, drag, buttons }

    private Quaternion lookRot = Quaternion.identity;
    private float angle = 0;
    private float dragAngle = 0;
    private bool chousedInput = false;
    private bool draging = false;

    void Update()
    {
        DragInput();
        if (!draging)
            SideInput();
#if UNITY_EDITOR
        ButtonsInput();
#endif
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, lerpIndex);
    }

    void SideInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.mousePosition.x - Screen.width / 2 < 0)
            {
                UpdateAngle(true);
            }
            else
            {
                UpdateAngle(false);
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
        float x;
        if (GameManager.Instance.IsRevertControl)
            x = -1 * (Input.mousePosition.x - Screen.width / 2);
        else
            x = Input.mousePosition.x - Screen.width / 2;
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
    }

    void ButtonsInput()
    {
        KeyRotate();

        lookRot = Quaternion.LookRotation(transform.forward, GetLookAtVec());
    }

    private void KeyRotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            UpdateAngle(true);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            UpdateAngle(false);
        }
    }

    private void UpdateAngle(bool isLeft)
    {
        int increase;
        increase = isLeft ? (GameManager.Instance.IsRevertControl ? -1 : 1) : (GameManager.Instance.IsRevertControl ? 1 : -1);
        angle += increase* rotateSpeed * Time.deltaTime;
    }
}
