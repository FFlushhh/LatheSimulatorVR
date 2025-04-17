using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearLever : MonoBehaviour
{
    public bool gearmesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gearmesh = gearlever();
    }

    public bool gearlever()
    {
        float currentZrotation = this.transform.rotation.eulerAngles.z;
        
        // TODO 角度によってTrueを返すかFalseを返すかを実装
        return true;
    }
}
