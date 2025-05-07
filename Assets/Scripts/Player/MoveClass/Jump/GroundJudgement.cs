using UnityEngine;

/// <summary>
/// ジャンプ中、地面判定をとる処理のクラス
/// </summary>
public class GroundJudgement : MonoBehaviour
{
    //レイの長さ
    private const float RAY_LENGTH = 1f;

    //レイの当たってほしいレイヤーマスク(6bitの値)
    private const int GROUND_LAYER = 64;

    /// <summary>
    /// 地面があるかの判定を取る
    /// </summary>
    /// <returns>trueで床に当たった判定、falseは何も当たってないか床じゃない判定</returns>
    public bool GroundJudge()
    {

        Vector3 rayStartPosition = this.gameObject.transform.position;

        //レイを下向きに飛ばし、オブジェクトに当たったかの判定をとる
        if (Physics.Raycast(rayStartPosition, Vector3.down, RAY_LENGTH, GROUND_LAYER))
        {
            // GROUND_LAYERに当たったらtrueを返す
            return true;
        }
        //何も当たってないならfalseを返す
        return false;
    }
}
