using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2Mgr : MonoBehaviour
{ 
    // 搖晃閾值，可根據實際情況調整
    public float shakeThreshold = 3.0f;

    // 上一幀的加速度
    private Vector3 lastAcceleration;

    public Button btnReset;
    public Text txScore;

    public List<GameObject> IngredientList;
    
    private void Start()
    {
        btnReset.gameObject.SetActive(false);
        txScore.gameObject.SetActive(false);
        
        btnReset.onClick.AddListener(OnBtnResetClick);
        
    }

    private void OnBtnResetClick()
    {
        //重新產生素材 
        for (int i = 0; i < IngredientList.Count; i++)
        {
            IngredientList[i].SetActive(true);
        }
        
        //重新貓咪需求(出題) 
        
        //重設分數
        GameDB.score = 0;

        //隱藏結果
        btnReset.gameObject.SetActive(false);
        txScore.gameObject.SetActive(false);
    }


    void Update()
    {
        // 獲取當前加速度
        Vector3 currentAcceleration = Input.acceleration;

        // 計算加速度變化量
        Vector3 deltaAcceleration = currentAcceleration - lastAcceleration;
        float accelerationMagnitude = deltaAcceleration.magnitude;

        // 判斷是否發生搖晃
        if (accelerationMagnitude > shakeThreshold)
        {
            Debug.Log("Shake detected!");
            // 在此處添加你的搖晃響應邏輯

            txScore.text = GameDB.score.ToString();
            btnReset.gameObject.SetActive(true);
            txScore.gameObject.SetActive(true);
            
        }

        // 更新上一幀的加速度
        lastAcceleration = currentAcceleration;
    }
}
