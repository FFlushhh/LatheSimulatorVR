using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShaftSpeedCenter : MonoBehaviour
{
    //shaft speed centerにアタッチ　（speed　hundle　centerではない）
    [SerializeField] private GameObject speed_hundle_position;
    //[SerializeField] private GameObject test;
    [SerializeField] private GameObject speed_hundle;
    private float previousZRotation;
    [SerializeField] private AudioSource audioSource;
    private bool _hasPlayed = false;
    //public enum RotationSpeed{speed1,speed2,speed3,speed4,speed5,speed6,speed7,speed8}
    [SerializeField] ObjectRotator objectRotator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        objectRotator = objectRotator.GetComponent<ObjectRotator>();
        speed_hundle.transform.rotation = Quaternion.Euler(0, 0, 90f);
        previousZRotation = speed_hundle_position.transform.rotation.eulerAngles.z;
        this.transform.rotation = Quaternion.Euler(0, 0, 30f);//元画像の傾きを補正しているためZ座標が０ではない。

    }

    // Update is called once per frame
    void Update()
    {
        //ハンドルがどちらの方向に動いているか判定する関数
        move();
        ////enum RotationSpeedを回転数ごとに返す関数
        getValue();
        //Debug.Log(test.transform.rotation.eulerAngles);
        //Debug.Log(test.transform.position);
    }
    void move()
    {
        float currentZRotation = speed_hundle_position.transform.rotation.eulerAngles.z ;
        float rotationDelta = currentZRotation - previousZRotation;

        if (rotationDelta > 180)
        {
            rotationDelta -= 360;
        }
        else if (rotationDelta < -180)
        {
            rotationDelta += 360;
        }

        // if (280 <= currentZRotation && currentZRotation <= 320 && !hasPlayed){
        //     audioSource.Play();
        //     hasPlayed = true;
        // }else if((currentZRotation < 280 || currentZRotation > 320) && hasPlayed){
        //     hasPlayed = false;
        // }
        if (80 <= currentZRotation && currentZRotation <= 100 && !_hasPlayed)
        {
            audioSource.Play();
            _hasPlayed = true;
        }
        else if ((currentZRotation < 80 || currentZRotation > 100) && _hasPlayed)
        {
            _hasPlayed = false;
        }


        //shaft speed centerの回転速度をspeed　hundle　centerの回転速度を8分の一にして動かす。
        this.transform.Rotate(0, 0, rotationDelta / 8.0f);
        previousZRotation = currentZRotation;
    }
    
     public float GG(){
        float this_currentZRotation = this.transform.rotation.eulerAngles.z;
        return this_currentZRotation;
     }
    public ObjectRotator.RotationSpeed getValue()
    {
        //判定(0~7)
        float this_currentZRotation = this.transform.rotation.eulerAngles.z;
        
        //currentcount1 = float.Parse(currentcount1.ToString("f1"));
        int currentcount_46 =Mathf.FloorToInt(this_currentZRotation / 45 * 10 % 10);
        if(currentcount_46 >= 4 && currentcount_46 <= 6)
        {
            // audioSource.time = 1f;
            // audioSource.Play();
        }


        int currentcount = (int)this_currentZRotation / 45; 
        if(currentcount==4)
        {
            Debug.Log("speed1");
            return ObjectRotator.RotationSpeed.speed1;
        }
        if(currentcount==3)
        {
            Debug.Log("speed2");
            return ObjectRotator.RotationSpeed.speed2;
        }
        if(currentcount==2)
        {
            Debug.Log("speed3");
            return ObjectRotator.RotationSpeed.speed3;
        }
        if(currentcount==1)
        {
            Debug.Log("speed4");
            return ObjectRotator.RotationSpeed.speed4;
        }
        if(currentcount==0)
        {
            Debug.Log("spee5");
            return ObjectRotator.RotationSpeed.speed5;
        }
        if(currentcount==7)
        {
            Debug.Log("speed6");
            return ObjectRotator.RotationSpeed.speed6;
        }
        if(currentcount==6)
        {
            Debug.Log("speed7");
            return ObjectRotator.RotationSpeed.speed7;
        }
        Debug.Log("speed8");
        return ObjectRotator.RotationSpeed.speed8;
    }

}

/*
shaft speed center  L,H(currentcount)
-180_z_-135         25,81(4)
135_z_180           41,129(3)
90_z_135            66,208(2)
45_z_90             103,325(1)
0_z_45              158,500(0)
-45_z_0             250,795(7)
-90_z_-45           410,1280(6)
-135_z_-90          635,2000(5)
*/
