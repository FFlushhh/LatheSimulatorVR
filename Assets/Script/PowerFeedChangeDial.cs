using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// public class PowerFeedChangeDial : MonoBehaviour
// {
//     [SerializeField] private GameObject _PowerFeedChangeDialBack;
//     public enum ChangeDialEnum 
//         {grabbed, 
//         A1, A2, A3, A4, A5, A6, A7, A8,
//         B1, B2, B3, B4, B5, B6, B7, B8,
//         C1, C2, C3, C4, C5, C6, C7, C8,
//         D1, D2, D3, D4, D5, D6, D7, D8,
//         };// TOOD feed table（値表）をもとに値を調整
//     bool isGrabbed;
//     // Start is called before the first frame update
//     void Start()
//     {
//         isGrabbed = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float _FrontAng = this.gameObject.transform.rotation.eulerAngles.z;
//         float _BackAng = _PowerFeedChangeDialBack.transform.rotation.eulerAngles.z;
//         AngleJudge(isGrabbed,_FrontAng,_BackAng);                       //内部の変数も変更しておく
//         // DialSpeed();
//     }

//     public int DEB()
//     {
//         float _Pos = this.gameObject.transform.rotation.eulerAngles.z;
//         float _BackPos = _PowerFeedChangeDialBack.transform.rotation.eulerAngles.z;
//         return 1000*(int)_Pos + (int)_BackPos;
//     }

//     void AngleJudge(bool isGrabbed, float _Pos, float _BackPos)
//     {
//         if (isGrabbed)
//             return;

//         const int _BaseAngle_A_1 = 0;               // ダイヤルの角度 0°=360°
//         const int _BaseAngle_A_2 = 360;             // ダイヤルの角度 0°=360°
//         const int _BaseAngle_B = 90;                // ダイヤルの角度 90°
//         const int _BaseAngle_C = 180;               // ダイヤルの角度 180°
//         const int _BaseAngle_D = 270;               // ダイヤルの角度 270°

//         const int _BaseAngle_1_1 = 0;               // ダイヤルの角度 0°=360°
//         const int _BaseAngle_1_2 = 360;             // ダイヤルの角度 0°=360°
//         const int _BaseAngle_2 = 45;                // ダイヤルの角度 45°
//         const int _BaseAngle_3 = 90;                // ダイヤルの角度 90°
//         const int _BaseAngle_4 = 135;               // ダイヤルの角度 135°
//         const int _BaseAngle_5 = 180;               // ダイヤルの角度 180°
//         const int _BaseAngle_6 = 225;               // ダイヤルの角度 225°
//         const int _BaseAngle_7 = 270;               // ダイヤルの角度 270°
//         const int _BaseAngle_8 = 315;               // ダイヤルの角度 315°

//         const int _AdjustAreaEdge_Left = -45;       // 補正を実行する角度の範囲の左端
//         const int _AdjustAreaEdge_Right = 45;       // 補正を実行する角度の範囲の右端

//         const int _AdjustAreaEdge_Left_Back = -22;  // 補正を実行する角度の範囲の左端
//         const int _AdjustAreaEdge_Right_Back = 23;  // 補正を実行する角度の範囲の右端

//         Vector3 _CurrentFrontAngle;                 //現在の手前のダイヤルの角度の設定用
//         Vector3 _CurrentBackAngle;                  //現在の奥のダイヤルの角度の設定用

//         // 手前側のダイヤルの角度調整
//         if (_BaseAngle_A_2 + _AdjustAreaEdge_Left < _Pos && _Pos <= _BaseAngle_A_1 + _AdjustAreaEdge_Right) {
//             _CurrentFrontAngle = new Vector3(0, 0, _BaseAngle_A_1);
//         }
//         else if (_BaseAngle_B + _AdjustAreaEdge_Left < _Pos && _Pos <= _BaseAngle_B + _AdjustAreaEdge_Right) {
//             _CurrentFrontAngle = new Vector3(0, 0, _BaseAngle_B);
//         }
//         else if (_BaseAngle_C + _AdjustAreaEdge_Left < _Pos && _Pos <= _BaseAngle_C + _AdjustAreaEdge_Right) {
//             _CurrentFrontAngle = new Vector3(0, 0, _BaseAngle_C);
//         }
//         else {
//             _CurrentFrontAngle = new Vector3(0, 0, _BaseAngle_D);
//         }
//             this.transform.localEulerAngles = _CurrentFrontAngle; 

//         // 奥側のダイヤルの角度調整
//         if (_BaseAngle_1_2 + _AdjustAreaEdge_Left_Back < _BackPos || _BackPos <= _BaseAngle_1_1 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_1_1);
//         }
//         else if (_BaseAngle_2 + _AdjustAreaEdge_Left_Back < _BackPos && _BackPos <= _BaseAngle_2 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_2);
//         }
//         else if (_BaseAngle_3 + _AdjustAreaEdge_Left_Back < _BackPos && _BackPos <= _BaseAngle_3 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_3);
//         }
//         else if (_BaseAngle_4 + _AdjustAreaEdge_Left_Back < _BackPos && _BackPos <= _BaseAngle_4 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_4);
//         }
//         else if (_BaseAngle_5 + _AdjustAreaEdge_Left_Back < _BackPos && _BackPos <= _BaseAngle_5 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_5);
//         }
//         else if (_BaseAngle_6 + _AdjustAreaEdge_Left_Back < _BackPos && _BackPos <= _BaseAngle_6 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_6);
//         }
//         else if (_BaseAngle_7 + _AdjustAreaEdge_Left_Back < _BackPos && _BackPos <= _BaseAngle_7 + _AdjustAreaEdge_Right_Back) {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_7);
//         }
//         else {
//             _CurrentBackAngle = new Vector3(-90, 0, _BaseAngle_8);
//         }
//         _PowerFeedChangeDialBack.transform.localEulerAngles = _CurrentBackAngle;
//     }

    
//     public ChangeDialEnum DialSpeed()//製作中
//     {
//         return ChangeDialEnum.A1;
//     }

//     public void Select()
//     {
//         isGrabbed = true;
//     }

//     public void UnSelect()
//     {
//         isGrabbed = false;
//     }
//}



public class PowerFeedChangeDial : MonoBehaviour
{
    [SerializeField] private GameObject _powerFeedChangeDialBack;
    
    [SerializeField] private List<TMP_Text> tMP_Texts;//デバック用
    [SerializeField] private AudioSource _audioSource;
    private bool _hasPlayed = false;


   public enum ChangeDialEnum
   {
   grabbed,
   A1, A2, A3, A4, A5, A6, A7, A8,
    B1, B2, B3, B4, B5, B6, B7, B8,
    C1, C2, C3, C4, C5, C6, C7, C8,
    D1, D2, D3, D4, D5, D6, D7, D8,
    }
    private bool _isGrabbed;
    
    private readonly int[] frontAngles = new int[] { 0, 90, 180, 270 };
    private readonly int[] backAngles = new int[] { 0, 45, 90, 135, 180, 225, 270, 315 };
    private const int frontThreshold = 45;  //閾値
    private const int backThreshold = 23;   //閾値

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _isGrabbed = false;

    }
    private void Update()
    {
        if (_isGrabbed)
        {
            _hasPlayed = false;
            
        }
        else
        {
            float frontAngle = transform.rotation.eulerAngles.z;
            float backAngle = _powerFeedChangeDialBack.transform.rotation.eulerAngles.z;
            int frontIndex = GetNearestAngleIndex(frontAngles, frontAngle, frontThreshold, false);
            int backIndex = GetNearestAngleIndex(backAngles, backAngle, backThreshold, true);

            ChangeDialEnum result = DialSpeed(frontIndex + 1, backIndex + 1);

            tMP_Texts[0].text = result.ToString(); // デバック用
        } 
        tMP_Texts[1].text ="_isGrabbed:"+_isGrabbed.ToString(); // デバック用
    }



    private int GetNearestAngleIndex(int[] angleSet, float angle, int threshold, bool isBack)
    {
        for (int i = 0; i < angleSet.Length; i++)
        {
            float delta = Mathf.DeltaAngle(angle, angleSet[i]);//与えられた2つの角度（単位は度）間の最小の差を計算
            if (Mathf.Abs(delta) <= threshold )
            {
                Vector3 newRotation= new Vector3(-90, 0, angleSet[i]);
                // 角度が一致した場合、ダイヤルの回転を設定
                if (isBack)
                {
                    _powerFeedChangeDialBack.transform.localEulerAngles = newRotation;
                    playAudio();
                }
                else
                {
                    this.transform.localEulerAngles = newRotation;   
                    playAudio();
                }   
                return i;
            } 
        }

        // 閾値内に一致しない場合、最後の角度にスナップ
        int fallbackIndex = angleSet.Length - 1;
        Vector3 fallbackRotation = new Vector3(-90, 0, angleSet[fallbackIndex]);

        // 角度が一致しない場合、ダイヤルの回転を設定
        if (isBack)
        {
            _powerFeedChangeDialBack.transform.localEulerAngles = fallbackRotation;

        }
        else
        {
            this.transform.localEulerAngles = fallbackRotation;
        }
        return fallbackIndex;
    }
    public ChangeDialEnum DialSpeed(int front, int back)//台速度設定出力
    {
        int index = (front - 1) * 8 + (back - 1);
        ChangeDialEnum result = (ChangeDialEnum)(index + 1); // enumのgrabbedをスキップ
        return result;
    }

    void playAudio()
    {
        if (_hasPlayed) 
        {
            _audioSource.Play();
            _hasPlayed = true; 
        }  
    }

    public void Select()
    {
        _isGrabbed = true;
    }
    public void UnSelect()
    {
        _isGrabbed = false;
    }
    public int DEB()
    {
        float front = transform.rotation.eulerAngles.z;
        float back = _powerFeedChangeDialBack.transform.rotation.eulerAngles.z;
        int result = 1000 * (int)front + (int)back;
        return result;
    }
}
 

