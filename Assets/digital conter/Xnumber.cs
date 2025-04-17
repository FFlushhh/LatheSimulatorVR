using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Xnumber : MonoBehaviour
{
    public Carriage CarriageReference;
    public TextMeshProUGUI distanceText;
    private float initialZ;

    void Start()
    {
        initialZ = CarriageReference.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Zキーで距離をリセット
        if (Input.GetKeyDown(KeyCode.X))
        {
            initialZ = CarriageReference.transform.position.z;  // 現在位置を新しい初期位置として設定
            distanceText.text = "0";
        }
        // 通常の距離表示の更新
        else if (distanceText != null)
        {
            float currentDistance = (CarriageReference.transform.position.z - initialZ);
            float distanceInMM = currentDistance * 1000f;
            distanceText.text = $"{-distanceInMM:F1}";
        }
    }
}
