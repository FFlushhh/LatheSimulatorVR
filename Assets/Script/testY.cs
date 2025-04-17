using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testY : MonoBehaviour
{
    [SerializeField]private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int test = (int)Time.deltaTime % 2;
        if(test==0)
        {
            transform.Rotate(0, speed*Time.deltaTime, 0);
        }  
    }
}
