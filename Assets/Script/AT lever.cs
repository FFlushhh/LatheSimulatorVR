using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATlever : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        aTlever();
    }
    public bool aTlever()
    {
        float currentXrotation = this.transform.rotation.eulerAngles.x; //初期270反時計回りで＋ 何故かZじゃない。
        if (currentXrotation >= 310){//MAX:270+45=315
            return true;
        }
        else{
            return false;
        }
    }

    public float aTlever2()
    {
        float currentXrotation = this.transform.rotation.eulerAngles.x;
        return currentXrotation;
    }
}
