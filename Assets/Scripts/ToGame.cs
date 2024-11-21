using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入場景管理命名空間

public class ToGame : MonoBehaviour
{
    public void SwitchScene(string Game)
    {
        SceneManager.LoadScene(Game);
    }
}
