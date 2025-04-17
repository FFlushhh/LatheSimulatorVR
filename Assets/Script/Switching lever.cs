using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchinglever : MonoBehaviour
{
    int ho =6; //補正値
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        switchinglever();
    }
    
    public maintable._enum switchinglever()
    {
        float currentXrotation = this.transform.rotation.eulerAngles.x - ho; //初期270(補正込)反時計回りで＋ 何故Zじゃない
        if (currentXrotation <= 275){
            return maintable._enum.left;
        }
        else if(currentXrotation >= 345){
            return maintable._enum.right;
        }else{
            return maintable._enum.Neutral;
        }
    }

    public float switchinglever2()
    {
        float currentXrotation = this.transform.rotation.eulerAngles.x - ho;//何故か269.9~348.09が可動域になる。
        return currentXrotation;
    }
}
