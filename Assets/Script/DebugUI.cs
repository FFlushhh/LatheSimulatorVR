using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugUI : MonoBehaviour
{
    // [SerializeField]private GameObject DebugOBJ;
    // [SerializeField]private GameObject DebugOBJ2;
    // [SerializeField]private GameObject DebugOBJ3;
    // [SerializeField]private GameObject DebugOBJ4;
    
    // [SerializeField] private TMP_Text tMP_Text;
    // [SerializeField] private TMP_Text tMP_Text2;
    // [SerializeField] private TMP_Text tMP_Text3;
    // [SerializeField] private TMP_Text tMP_Text4;
    // [SerializeField] private TMP_Text tMP_Text5;
    // [SerializeField] private TMP_Text tMP_Text6;
    // [SerializeField] private TMP_Text tMP_Text7;
    // [SerializeField] private TMP_Text tMP_Text8;
    [SerializeField]private List<GameObject> DebugOBJs;
    [SerializeField] private List<TMP_Text> tMP_Texts;
    private StartJudge startJudge;
    private ATlever _ATlever;
    private Switchinglever switchinglever;
    private ObjectRotator  objectRotator;
    private ShaftSpeedCenter shaftSpeedCenter;
    private ShaftSpeedConvert shaftSpeedConvert;
    private PowerFeedChangeDial powerFeedChangeDial;

    // Start is called before the first frame update
    void Start()
    {
        // tMP_Text = GetComponent<TMP_Text>();
        // tMP_Text2 = GetComponent<TMP_Text>();
        startJudge = DebugOBJs[0].GetComponent<StartJudge>();
        _ATlever = DebugOBJs[1].GetComponent<ATlever>();
        switchinglever = DebugOBJs[2].GetComponent<Switchinglever>();
        objectRotator = DebugOBJs[3].GetComponent<ObjectRotator>();
        shaftSpeedCenter = DebugOBJs[4].GetComponent<ShaftSpeedCenter>();
        shaftSpeedConvert = DebugOBJs[5].GetComponent<ShaftSpeedConvert>();
        powerFeedChangeDial = DebugOBJs[12].GetComponent<PowerFeedChangeDial>();

    }

    // Update is called once per frame
    void Update()
    {
        //tMP_Text.text = DebugOBJ.transform.rotation.y.ToString("F3");
        //tMP_Text.text = DebugOBJ.transform.localEulerAngles.x.ToString("F3");
        tMP_Texts[0].text = startJudge.startjudge().ToString();
        tMP_Texts[1].text = startJudge.startjudge2().ToString();
        tMP_Texts[2].text = _ATlever.aTlever().ToString();
        tMP_Texts[3].text = _ATlever.aTlever2().ToString();
        tMP_Texts[4].text = switchinglever.switchinglever().ToString();
        tMP_Texts[5].text = switchinglever.switchinglever2().ToString();
        tMP_Texts[6].text = objectRotator._isRotating().ToString();
        tMP_Texts[7].text = "ConvertRotation:" + DebugOBJs[4].transform.rotation.eulerAngles.y.ToString("000");
        tMP_Texts[8].text = "ShaftSpeedRotation:" + DebugOBJs[5].transform.rotation.eulerAngles.z.ToString("000");
        // tMP_Texts[9].text = shaftSpeedConvert.getValue().ToString();
        // tMP_Texts[10].text = shaftSpeedCenter.getValue().ToString();
        // tMP_Texts[11].text = shaftSpeedCenter.GG().ToString();
        tMP_Texts[12].text = DebugOBJs[8].transform.rotation.eulerAngles.z.ToString("000");
        tMP_Texts[13].text = DebugOBJs[9].transform.rotation.eulerAngles.z.ToString("000");
        tMP_Texts[14].text = DebugOBJs[10].transform.rotation.eulerAngles.z.ToString("000");
        tMP_Texts[15].text = DebugOBJs[11].transform.position.ToString("000.0000000000");
        tMP_Texts[16].text = powerFeedChangeDial.DEB().ToString("000000");
        tMP_Texts[17].text = DebugOBJs[13].transform.rotation.eulerAngles.y.ToString("000");
    }
}
