using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

public class ObjectRotator : MonoBehaviour
{
    public UIManager uiManager;
    // 回転速度の列挙型
    public enum RotationSpeed
    {
        speed1, speed2, speed3, speed4, speed5, speed6, speed7, speed8
    }
    // スイッチの状態の列挙型
    public enum Lever
    {
        High,
        Low,
        Neutral
    }
    private int[,] Speed = new int[3, 8]
    {
    //High
    {81,129,208,325,500,795,1280,2000},
    //Low
    {25,41,66,103,158,250,410,635},
    //Neutral
    {0,0,0,0,0,0,0,0}

    };
    [SerializeField] private AudioClip spindleStartClip;
    [SerializeField] private AudioClip spindleEndClip;
    [HideInInspector] public bool startlever = false;
    [HideInInspector] public Lever currentLever = Lever.Neutral;
    [HideInInspector] public RotationSpeed currentSpeed = RotationSpeed.speed1;
    [HideInInspector] public bool clockwise = true;// 回転方向（時計回りかどうか）
    public KeyCode toggleKey = KeyCode.Space;// 回転のオン/オフを切り替える
    private float rotationAmount = 0f;
    [HideInInspector] public bool isRotating = false; //主軸回転のオンオフ
    [SerializeField] private AudioSource startleverAudioSource;
    private ShaftSpeedConvert shaftSpeedConvert;
    public ShaftSpeedCenter shaftSpeedCenter;
    public StartJudge startJudge;
    private AudioSource spindleAudioSource;
    private bool currentisRotating = false;

    void Start()
    {
        if (shaftSpeedConvert == null)
        {
            shaftSpeedConvert = FindObjectOfType<ShaftSpeedConvert>();
        }
        if (shaftSpeedCenter == null)
        {
            shaftSpeedCenter = FindObjectOfType<ShaftSpeedCenter>();
        }
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        //ShaftSpeedConvert.Test();
        spindleAudioSource = GetComponent<AudioSource>();
        startleverAudioSource = startleverAudioSource.GetComponent<AudioSource>();
    }
    public bool _isRotating(){if(startJudge.startjudge()){return true;}else{return false;}}//デバック用

    void Update()
    {
        //if (Input.GetKeyDown(toggleKey)){Debug.Log("Start");UpdateLeverAndSpeed();RotateStart();}
        //if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)){audioSource.Play();UpdateLeverAndSpeed();RotateStart();}
        //SetRotationSpeed();//値を設定
        isRotating = startJudge.startjudge();
        if(isRotating != currentisRotating){
            if (isRotating){

                //このままだと、起動中に速度を変えられるので、どうにかする。Meta側でつかめなくするのがよさそう。

                UpdateLeverAndSpeed();      //値を引っ張ってくる。
                RotateStart();              //音を鳴らして、値を設定
            }else{
                spindleAudioSource.loop = false;
                spindleAudioSource.clip = spindleEndClip;
                spindleAudioSource.Play();
                
                if(rotationAmount > 0){
                    rotationAmount -= 0.1f; 
                }
                rotationAmount = 0; 
            }
        }

        transform.Rotate(Vector3.right, rotationAmount * Time.deltaTime);//実際に動かす。
        currentisRotating = isRotating;

        // uiManager.UpdateStateUI(currentLever);
        // uiManager.UpdateSpeedUI(currentSpeed);
        //    if (isRotating)
        //    {
        //        transform.Rotate(Vector3.right, rotationAmount * Time.deltaTime);
        //    }
    }

    void UpdateLeverAndSpeed()
    {
        if (shaftSpeedConvert != null)
        {
            currentLever = shaftSpeedConvert.getValue();
            if (uiManager != null){
                uiManager.UpdateStateUI(currentLever);
            }
        }

        if (shaftSpeedCenter != null)
        {
            currentSpeed = shaftSpeedCenter.getValue();
            if (uiManager != null){
                uiManager.UpdateSpeedUI(currentSpeed);
            }
        }

        // if (isRotating)
        // {
        //     SetRotationSpeed(); //回転速度の設定
        // }
    }

    void RotateStart()
    {
        startleverAudioSource.Play();
        spindleAudioSource.clip = spindleStartClip;
        spindleAudioSource.loop = true;
        spindleAudioSource.Play();
        SetRotationSpeed();
    }

    void SetRotationSpeed()
    {
        int leverIndex = (int)currentLever;
        int speedIndex = (int)currentSpeed;

        if (leverIndex >= 0 && leverIndex < 3 && speedIndex >= 0 && speedIndex < 8)
        {
            rotationAmount = Speed[leverIndex, speedIndex];
            if (uiManager != null)
            {
                //Debug.Log(rotationAmount);                                                                                                                                                                                                                                                                                                
                uiManager.UpdaterotateUI(rotationAmount);
            }
        }
        else
        {
            //isRotating = false;
        }

    }
}