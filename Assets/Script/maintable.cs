using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;

public class maintable : MonoBehaviour
{
    public Zhandle_2 zhandleReference;
    public float speed = 0.05f;     // 台の移動速度
    public float minX = -0.95f;
    public float maxX = -0.15f;
    [HideInInspector]public bool isMovingForward = false; // 前方移動中かどうかのフラグ
    [HideInInspector]public bool isMovingBackward = false; // 後方移動中かどうかのフラグ
    public ATlever aTlever;
    public Switchinglever switchinglever;
    public ObjectRotator objectRotator;
    public bool atbool;

    public enum _enum {left,right,Neutral};
    public _enum swenum = _enum.left;

    void Start(){
        //transform.position = new Vector3();
        //maxX = transform.position.x;
    }
    
    void Update()
    {
        Auto();
        Hand();
    }

    void Auto()
    {
        swenum = switchinglever.switchinglever();
        atbool = aTlever.aTlever();
        if (atbool && objectRotator.isRotating){
            // swithingleverチェック
            if (swenum == _enum.left)
            {
                isMovingForward = !isMovingForward;
                isMovingBackward = false; // 前方移動時は後方移動をキャンセル
            }
            if (swenum == _enum.right)
            {
                isMovingBackward = !isMovingBackward;
                isMovingForward = false; // 後方移動時は前方移動をキャンセル
            }
        
            // 移動処理
            if(isMovingForward)
            {
                // x軸方向に一定速度で前方に移動
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            else if(isMovingBackward)
            {
                // x軸方向に一定速度で後方に移動
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            // 移動範囲の制限
            Vector3 currentPosition = transform.position;
            float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);
            if (currentPosition.x != clampedX)
            {
                isMovingForward = false;
                isMovingBackward = false;
                // 範囲内に収める
                transform.position = new Vector3(clampedX, currentPosition.y, currentPosition.z);
            }
        }
    
    }

    void Hand()
    {
        if (zhandleReference.isMovingForward)
        {
            // zhandleがz軸を中心に左回転しているとき、前方に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        }
        else if (zhandleReference.isMovingBackward)
        {
            // zhandleがz軸を中心に右回転しているとき、後方に移動
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        
        Vector3 currentPosition = transform.position;
        float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);

        if (currentPosition.x != clampedX)
        {
            zhandleReference.isMovingForward = false;
            zhandleReference.isMovingBackward = false;
            transform.position = new Vector3(clampedX, currentPosition.y, currentPosition.z);
        }

    }
}