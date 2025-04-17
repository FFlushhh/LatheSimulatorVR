using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// using Meta.WitAi.Utilities;
using Unity.VisualScripting;
using UnityEngine;

public class SquareTablePosSet : MonoBehaviour
{
    [SerializeField] private GameObject _squaretablecenter;
    
    
    public void AngleJudge()//この関数はHandGrabに入っているコンポーネントで使用している。
    {  
        float _angle = _squaretablecenter.transform.localEulerAngles.y;
        Vector3 _CurrentAngle;
        if (45 <= _angle && _angle < 135) {
            _CurrentAngle = new Vector3(0, 90, 0);
        }
        else if (135 <= _angle &&  _angle < 225) {
            _CurrentAngle = new Vector3(0, 180, 0);
        }
        else if (225 <= _angle &&  _angle < 315) {
            _CurrentAngle = new Vector3(0, 270, 0);
        }
        else if ((315 <= _angle && _angle <= 360) || (0 <= _angle && _angle < 45)) {
            _CurrentAngle = new Vector3(0, 0, 0);
        }
         else {
             _CurrentAngle = new Vector3(0, 0, 0);
        }
        _squaretablecenter.transform.localEulerAngles = _CurrentAngle;

    }
    

    //private bool _isGrabbed;


    // public void AngleJudge(bool isGrabbed,float _angle){  
    //     if (isGrabbed){
    //         return;
    //     }

    //     Vector3 _CurrentAngle;
    //     if (45 <= _angle && 135 < _angle) {
    //         _CurrentAngle = new Vector3(0, 90, 0);
    //     }
    //     else if (135 <= _angle && 225 < _angle) {
    //         _CurrentAngle = new Vector3(0, 180, 0);
    //     }
    //     else if (225 <= _angle && 315 < _angle) {
    //         _CurrentAngle = new Vector3(0, 270, 0);
    //     }
    //     else if ((315 <= _angle && 360 <= _angle) || (0 <= _angle && 45 < _angle)) {
    //         _CurrentAngle = new Vector3(0, 0, 0);
    //     }
    //      else {
    //          _CurrentAngle = new Vector3(0, 0, 0);
    //     }
    //     _test2.transform.localEulerAngles = _CurrentAngle;
 

    // }
    // public void Select()
    // {
    //     _isGrabbed = true;
    // }

    // public void UnSelect()
    // {
    //     _isGrabbed = false;
    // }
}
