using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using System.Threading.Tasks;
using UnityEngine;


public class ShaftSpeedConvert : MonoBehaviour
{
    //shaftspeed change centerにアタッチ
    //private ObjectRotator.Lever LEVER = ObjectRotator.Lever.Neutral;
    [SerializeField] ObjectRotator objectRotator;
    
    [SerializeField]private AudioSource audioSource;
    private bool hasPlayed = false;
    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();

        objectRotator = objectRotator.GetComponent<ObjectRotator>();

        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        //High, Low, Neutralの判別する関数
        //HNL();
        //enum Leverを段階ごとに返す関数
        getValue();
        PlaySound();
    }

    async void PlaySound(){
        float currentYRotation = this.transform.rotation.eulerAngles.y;
        
        if ( 26 <= currentYRotation  && currentYRotation <= 306 && !hasPlayed){
            audioSource.Play();
            hasPlayed = true;
            await Task.Delay(2000);
        }else if( 0 <= currentYRotation && currentYRotation < 26 || 306 < currentYRotation && currentYRotation <= 360 && hasPlayed){
            hasPlayed = false;
        }
    }

    // void HNL(){
    //     float currentYRotation = this.transform.rotation.eulerAngles.y;
        
    //     if (currentYRotation > 31 && currentYRotation < 301){

    //         if (currentYRotation < 166)//左上限
    //         {
    //             this.transform.rotation = Quaternion.Euler(0, 31, 0); 
    //         }
    //         else //右上限
    //         {
    //             this.transform.rotation = Quaternion.Euler(0, 301, 0);
    //         }
    //     }

    // }

    public ObjectRotator.Lever getValue(){
        float currentYRotation = this.transform.rotation.eulerAngles.y;
        //Debug.Log(currentYRotation);
        if (currentYRotation >= 31 && currentYRotation <= 301)
        {//HighLowに直接値を入れると変な感じになる。HighLowよりトリガー地点を少し早く設定するといいかも。しかも、直接入れただけだと押し込んだ時に音が消えてしまう。
            if (currentYRotation < 166)//Highの場合
            {
                Debug.Log("High");
                return ObjectRotator.Lever.High;
            }
            else //Lowの場合
            {
                Debug.Log("Low");
                return ObjectRotator.Lever.Low;
            }
        }
        else //Neutralの場合
        {
            Debug.Log("Neutral");
            return ObjectRotator.Lever.Neutral;
        }
    }
}
