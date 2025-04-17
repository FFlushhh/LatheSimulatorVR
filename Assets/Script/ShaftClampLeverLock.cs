using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftClampLeverLock : MonoBehaviour
{
    private float _Angle;
    public GameObject TailStockHundleHandGrab;
    // Start is called before the first frame update
    void Start()
    {
        _Angle = this.transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        _Angle = this.transform.rotation.eulerAngles.z;
        if (_Angle >= 315 && _Angle <= 320) {
            TailStockHundleHandGrab.SetActive(false);
        }
        else {
            TailStockHundleHandGrab.SetActive(true);
        }
    }
}
