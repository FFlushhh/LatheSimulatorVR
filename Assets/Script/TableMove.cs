using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TableMove : MonoBehaviour
{
    [SerializeField]private Transform handleposition;
    [SerializeField]private Transform verticalfeedhandlecenter;
    [SerializeField]private GameObject MoveTarget;
    [SerializeField]private float tableSpeed = 0.1f;
    [SerializeField]private Vector3 direction;
    [SerializeField]private Vector3 axis;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private float distance;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = handleposition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
      
        currentPosition = handleposition.position - verticalfeedhandlecenter.position;

        distance = Vector3.Distance(currentPosition, lastPosition);

        angle = Vector3.SignedAngle(lastPosition, currentPosition, axis);

        if (angle <= 0)
        {
            distance = Mathf.Abs(distance);  // 左回転
        }
        else
        {
            distance = -Mathf.Abs(distance);  // 右回転
        }

        MoveTarget.transform.position += direction * distance * tableSpeed * Time.deltaTime;
        lastPosition = currentPosition;
    }
}
