using UnityEngine;
using System.Collections;
using System.Diagnostics;

[RequireComponent(typeof(SelectRetry))]
public class GameOverAnimation : MonoBehaviour
{
    //ゲームオーバー時の看板のアニメーション
    [SerializeField, Header("ゲームオーバー時の看板のアニメーション")] private Animator _signBoardAnimation = default;

    [SerializeField, Header("ゲームオーバー時の岩のアニメーション")] private Animator _rockAnimation = default;
    //ゲームオーバー時のテキストを集合させたオブジェクト
    [SerializeField,Header("看板に表示するテキストを集合させた親オブジェクト")] private GameObject _gameOverTexts = default;

    [SerializeField] private AudioClip _gameOverSound = default;

    private PlaySE _playSE = default;
    private SelectRetry _selectRetry = default;

    private void Start()
    {
        _selectRetry = this.GetComponent<SelectRetry>();
        _playSE = new PlaySE();
    }

    /// <summary>
    /// ゲームオーバーのアニメーションを開始する
    /// </summary>
    public void StartGameOverAnimation()
    {
        _rockAnimation.SetBool("isRoll", true);
        StartCoroutine(StartSignBoardAnimation());
    }

   

    private IEnumerator StartSignBoardAnimation()
    {
        const float WAIT_TIME = 1.5f;
        yield return new WaitForSeconds(WAIT_TIME);
        _signBoardAnimation.SetInteger("AnimationNumber", 1);
        StartCoroutine(DisplayGameOverText());
        _playSE.StopSound();
        _playSE.PlaySound(_gameOverSound);
        yield break;
    }

    /// <summary>
    /// ゲームオーバーのテキストを表示する
    /// </summary>

    private IEnumerator DisplayGameOverText()
    {
        const int WAIT_TIME = 3;
        yield return new WaitForSeconds(WAIT_TIME);
        _gameOverTexts.SetActive(true);
        _selectRetry.StartSelect();
        yield break;
    }
}
