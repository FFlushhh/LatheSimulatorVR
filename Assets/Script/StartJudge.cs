using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJudge : MonoBehaviour
{
    public bool startbool;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        startjudge();
    }
    public bool startjudge()
    {
        float currentXrotation = this.transform.rotation.eulerAngles.x;//初期270手前で＋
        if (currentXrotation >= 278){//MAX:270+30=300
            startbool = true;
            return startbool;
        }
        else {
            startbool = false;
            return startbool;
        }
    }

    public float startjudge2()
    {
        float currentXrotation = this.transform.rotation.eulerAngles.x;
        return currentXrotation;
    }
}
