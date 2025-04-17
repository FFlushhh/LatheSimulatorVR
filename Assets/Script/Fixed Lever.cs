using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FixedLever : MonoBehaviour
{
    //private float _Yrotation;
    private bool isGrabbed;      // Metaでつかんでいるかどうか
    public GameObject SquareTableHandGrab;
    [System.NonSerialized]public bool FixedLeverLook;     //刃物台の回転ロック
    [System.NonSerialized]public bool FixedLeverLook_mid; // 刃の取付の可否

    //[SerializeField]private GameObject FixedLevercenter;
    [SerializeField]private List<TMP_Text> tMP_Text;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_Yrotation = FixedLevercenter.transform.rotation.eulerAngles.y;
        float _isXrotation = this.transform.eulerAngles.x;
        float _isYrotation = this.transform.rotation.eulerAngles.y;
        float _isZrotation = this.transform.rotation.eulerAngles.z;

        const int _AngleLockMin = 301;  // 刃物台の回転ロックの下限条件
        const int _AngleLockMax = 311;  // 刃物台の回転ロックの上限条件
        const int _AngleMidMin = 165;   // 刃の取付の可否の下限条件
        const int _AngleMidMax = 185;   // 刃の取付の可否の上限条件 

        //tMP_Text[0].text = "C"+_Yrotation.ToString();
        tMP_Text[2].text = (int)_isXrotation+":"+(int)_isYrotation+":"+(int)_isZrotation;

        if (!isGrabbed && _isYrotation >= _AngleLockMin && _isYrotation <= _AngleLockMax){
            FixedLeverLook = true;
            //SquareTableHandGrab.SetActive(false);
        }
        else {
            FixedLeverLook = false;
            //SquareTableHandGrab.SetActive(true);
        }

        if (!isGrabbed && _isYrotation >= _AngleMidMin && _isYrotation <= _AngleMidMax){
            // this.transform.localPosition = new Vector3(3.77601361f,-6.53811741f,0.98390913f);
            //this.transform.localEulerAngles = new Vector3(-90, -94, 0);
            FixedLeverLook_mid = true;
        }
        else {
            FixedLeverLook_mid = false;
        }

        if (FixedLeverLook_mid || FixedLeverLook){
            SquareTableHandGrab.SetActive(false);
        }
        else {
            SquareTableHandGrab.SetActive(true);
        }

        tMP_Text[1].text = FixedLeverLook.ToString(); 
    }

    public void Select()
    {
        isGrabbed = true;
    }

    public void UnSelect()
    {
        isGrabbed = false;
    }
}
