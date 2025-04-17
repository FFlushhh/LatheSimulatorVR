using UnityEngine;


public class Zhandle_2 : MonoBehaviour
{
    public float rotationSpeed; //回転速度(度/秒)
    public bool isMovingForward = false;
    public bool isMovingBackward = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isMovingForward = !isMovingForward;
            isMovingBackward = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            isMovingBackward = !isMovingBackward;
            isMovingForward = false;
        }

        if (isMovingForward)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        else if (isMovingBackward)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        
    }
}