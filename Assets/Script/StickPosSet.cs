
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPosSet : MonoBehaviour
{
    private bool _isGrabbed;
    private bool _isHitting;
    [SerializeField] private GameObject _stick;
    [System.NonSerialized]public bool SafetyKey; // チャックが定位置にあるかのチェック　trueの時、主軸が回転できるようになる。

    // Start is called before the first frame update
    void Start()
    {
        _isGrabbed = false;
        _isHitting = true;
    }  

    // Update is called once per frame
    void Update()
    {
        if (_isHitting) {

            SafetyKey = true;

            if(!_isGrabbed){
                _stick.transform.localPosition = new Vector3(0, 0, 0);
                _stick.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
                //ここにSE入れる。
            }
        }else{
            SafetyKey = false;
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

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "stick HitBox") {
            _isHitting = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.name == "stick HitBox") {
            _isHitting = false;
        }
    }
}
