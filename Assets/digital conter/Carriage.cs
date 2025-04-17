using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carriage : MonoBehaviour
{
    public Xhandle XhandleReference; //Carriageスクリプトへの参照    
    public float speed;
    public float minZ = -1f;
    public float maxZ = -0.75f;

    void Update()
    {
        if (XhandleReference.isMovingLeft)
        {
            // Carriageが前方に移動しているとき、z軸を中心に正の方向に回転
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (XhandleReference.isMovingRight)
        {
            // Carriageが後方に移動しているとき、z軸を中心に負の方向に回転
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        Vector3 currentPosition = transform.position;
        float clampedZ = Mathf.Clamp(currentPosition.z, minZ, maxZ);

        if (currentPosition.z != clampedZ)
        {
            XhandleReference.isMovingLeft = false;
            XhandleReference.isMovingRight = false;
            transform.position = new Vector3(currentPosition.x, currentPosition.y, clampedZ);
        }

    }

}