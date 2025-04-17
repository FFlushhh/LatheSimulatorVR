using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillPosSet : MonoBehaviour
{
    private bool isGrabbed;
    private bool _isHitting;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
        _isHitting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHitting && !isGrabbed) { // 時間があればDrillの根元でのコライダー判定もつける
            this.transform.localPosition = new Vector3(0, 0, 0);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            //ここにSE入れる。
        }
    }

    public void Select()
    {
        isGrabbed = true;
    }

    public void UnSelect()
    {
        isGrabbed = false;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "ShaftHitBox") {
            _isHitting = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.name == "ShaftHitBox") {
            _isHitting = false;
        }
    }
}
