using UnityEngine;

public class CalucationPlayerListPositionX
{
    //床生成オブジェクトの親のポジション
    private float floorPositionX = 0f;
    private float FloorPositionDivisionValue = 0f;

    private const int THREE_AWAY = 3;
    private const int TWO_AWAY = 2;
    private const int ONE_AWAY = 1;
    private const int HARF_LIST_LENGTH_X = 2;

    //二次元配列の真ん中の値
    private int _playerHarfListPoint = 0;

    public int PlayerListPositionX
    {
        get; private set;
    }


    public CalucationPlayerListPositionX(Transform FloorTransofrm, int listCount)
    {
        floorPositionX = FloorTransofrm.position.x;
        //地面のXの幅を７分割した時の一ブロック分の大きさ
        FloorPositionDivisionValue = FloorTransofrm.localScale.x / listCount;

        _playerHarfListPoint = listCount / HARF_LIST_LENGTH_X;
    }
    /// <summary>
    /// 真ん中からどれくらい離れているかを計算する
    /// </summary>
    public void LookFarAwayBrock(float playerPositionX)
    {
        //プレイヤーのポジションが+か-かを見る
        bool _positivePlayerPosition = JudgePositiveNumber(playerPositionX);

        //地面の真ん中から見て３ブロック分離れていたら
        if (JudgeFarAwayBlock(playerPositionX, THREE_AWAY))
        {
            PlayerPointChange(THREE_AWAY, _positivePlayerPosition);
            return;
        }
        //地面の真ん中から見て２ブロック分離れていたら
        else if (JudgeFarAwayBlock(playerPositionX, TWO_AWAY))
        {
            PlayerPointChange(TWO_AWAY, _positivePlayerPosition);
            return;
        }
        //地面の真ん中から見て１ブロック分離れていたら
        else if (JudgeFarAwayBlock(playerPositionX, ONE_AWAY))
        {
            PlayerPointChange(ONE_AWAY, _positivePlayerPosition);
            return;
        }
        //それ以外は０ブロックで返す
        PlayerPointChange(0, _positivePlayerPosition);
    }

    /// <summary>
    /// プレイヤーのポジションが正か負かを判別
    /// </summary>
    /// <param name="JudgeNumber">プレイヤーのポジション</param>
    /// <returns>trueが正、falseが負を表す</returns>
    private bool JudgePositiveNumber(float JudgeNumber)
    {
        if (JudgeNumber > 0)
        {
            //正だったらtrueを返す
            return true;
        }
        else
        {
            //負だったらfalseを返す
            return false;
        }
    }

    /// <summary>
    /// farAwayValue分離れているか見る処理
    /// </summary>
    /// <param name="playerPosition">プレイヤーのポジション</param>
    /// <param name="farAwayValue分離れているならtrue、そうでなければfalse">何ブロック離れているかを見る値</param>
    /// <returns>受け取った変数</returns>
    private bool JudgeFarAwayBlock(float playerPosition, int farAwayValue)
    {
        //プレイヤーのポジションを絶対値化
        float AbsolutePlayerPositionValueX = Mathf.Abs(playerPosition);

        //プレイヤーのポジションがfarAwayValue分離れていたら
        if (AbsolutePlayerPositionValueX >= floorPositionX + FloorPositionDivisionValue * farAwayValue - FloorPositionDivisionValue / 2)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 二次元配列の中でプレイヤーの現在地を変更
    /// </summary>
    /// <param name="FarAwayBrock">真ん中から見て離れているブロック数</param>
    /// <param name="JudgePositiveNumber">正の数字か判別</param>
    private void PlayerPointChange(int FarAwayBrock, bool JudgePositiveNumber)
    {
        if (JudgePositiveNumber)
        {
            PlayerListPositionX = _playerHarfListPoint + FarAwayBrock;
        }
        else
        {
            PlayerListPositionX = _playerHarfListPoint - FarAwayBrock;
        }
    }
}
