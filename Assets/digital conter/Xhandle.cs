using UnityEngine;
using TMPro;

public class Xhandle : MonoBehaviour
{
    public float rotationSpeed; // 回転速度（度/秒）
    public bool isMovingLeft = false;
    public bool isMovingRight = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMovingLeft = !isMovingLeft;
            isMovingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isMovingRight = !isMovingRight;
            isMovingLeft = false;
        }

        if (isMovingLeft)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        else if (isMovingRight)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
