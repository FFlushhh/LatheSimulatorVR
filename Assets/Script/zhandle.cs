using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhandle : MonoBehaviour
{
    public maintable mainTableReference; // maintableスクリプトへの参照
    //public StartJudge startJudge; // StartJudgeスクリプトへの参照
    public float rotationSpeed = 2000 ; // 回転速度（度/秒）
    private float speed;
   


    // void Start()
    // {
    //     mainTableReference = GetComponent<maintable>();
    // }

    void Update()
    {
        if (mainTableReference.atbool&&mainTableReference.objectRotator.isRotating){
            speed =  mainTableReference.speed * rotationSpeed;
            //transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
            
            if (mainTableReference.isMovingForward)
            {
                // maintableが前方に移動しているとき、z軸を中心に正の方向に回転
                transform.Rotate(0, speed * Time.deltaTime, 0);
            }
            else if (mainTableReference.isMovingBackward)
            {
                // maintableが後方に移動しているとき、z軸を中心に負の方向に回転
                transform.Rotate(0,  -speed * Time.deltaTime,0);
            }
        }
    }
}