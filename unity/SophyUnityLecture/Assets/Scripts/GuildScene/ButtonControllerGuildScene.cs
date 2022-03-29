using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンをロードするために導入
public class ButtonControllerGuildScene : MonoBehaviour
{
    //「戻る」ボタンがクリックされた時の処理
    public void ClickReturnButton()
    {
        //HomeSceneへ移動
        SceneManager.LoadScene("HomeScene");
    }
}