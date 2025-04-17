using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Znumber : MonoBehaviour
{
    public maintable maintableReference;
    public TextMeshProUGUI distanceText;
    private float initialX;
    void Start()
    {
        initialX = maintableReference.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Zキーで距離をリセット
        if (Input.GetKeyDown(KeyCode.Z))
        {
            initialX = maintableReference.transform.position.x;  // 現在位置を新しい初期位置として設定
            distanceText.text = "0";
        }
        // 通常の距離表示の更新
        else if (distanceText != null)
        {
            float currentDistance = (maintableReference.transform.position.x - initialX);
            float distanceInMM = currentDistance * 1000f;
            distanceText.text = $"{distanceInMM:F1}";
        }
    }
}
