using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailStockClampLock : MonoBehaviour
{
    private float _Angle;
    public GameObject TailstockHandGrab;
    // Start is called before the first frame update
    void Start()
    {
        _Angle = this.transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        _Angle = this.transform.rotation.eulerAngles.z;
        if (_Angle >= 0 && _Angle <= 5) {
            // 心押し台を動かさない
            TailstockHandGrab.SetActive(false);
        }
        else {
            TailstockHandGrab.SetActive(true);
        }
    }
}
