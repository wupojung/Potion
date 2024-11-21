using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入場景管理命名空間

public class ToField : MonoBehaviour
{
    public void SwitchScene(string Field)
    {
        SceneManager.LoadScene(Field);
    }
}
