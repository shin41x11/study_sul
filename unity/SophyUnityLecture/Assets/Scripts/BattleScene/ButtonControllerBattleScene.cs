using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Image型を扱うために導入
public class ButtonControllerBattleScene : MonoBehaviour
{
    [SerializeField] Text EnemyNameText = null;//エネミーの名前を表示させるTextオブジェクトとの連携のために導入
    [SerializeField] Text HpText = null;//エネミーのHPを表示させるTextオブジェクトとの連携のために導入
    [SerializeField] Image EnemyImage = null;//エネミー画像を表示させるImageオブジェクトとの連携のために導入

    [SerializeField] Image AttackEffectImage = null; //エネミーの攻撃エフェクトを表示されるImageオブジェクトとの連携用

    [SerializeField] Animator AnimationImage = null;//アニメーションを表示させるImageオブジェクトとの連携のために導入

    private int enemyID;
    private int enemyHP;

    private LoadEnemy enemyInfo;//CSVを読み込むLoadEnemyクラスを扱うために宣言
    //ゲーム起動時の動作
    private void Start()
    {
        enemyInfo = new LoadEnemy();//LoadEnemyクラスの実体としてenemyInfo生成
        enemyInfo.Init();//CSVデータの読み込みと変数への格納処理

        ClickShuffleButton();
    }

        public void ClickShuffleButton()
    {
        enemyID = choiceEnemyId();

        EnemyNameText.text = enemyInfo.enemyName[enemyID];
        EnemyImage.sprite = Resources.Load<Sprite>(enemyInfo.imageAddress[enemyID]);
        enemyHP = enemyInfo.hp[enemyID];

        HpText.text = "HP:" + enemyHP.ToString();

    }

    private int choiceEnemyId()
    {
        int result = Random.Range(1,6);
//        Debug.Log("choiceEnemyId:" + result);
        return result;
    }

        //攻撃ボタンが押された時の処理
    public void ClickAttackButton()
    {
        //AttackTriggerをONにする処理
        string triggerName = enemyInfo.attackEffectTrigger[enemyID];
//        Debug.Log("triggerName:" + triggerName);
        AnimationImage.SetTrigger(triggerName);
        //EmptyTriggerをONにする処理
        AnimationImage.SetTrigger("EmptyTrigger");

        // HPをへらす
        enemyHP--;
        HpText.text = "HP:" + enemyHP.ToString();
    }
}