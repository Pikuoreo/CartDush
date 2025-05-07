using UnityEngine;

/// <summary>
/// プレイヤーの左右移動処理のクラス
/// </summary>
public class PlayerHorizontalMove : MonoBehaviour
{
    //ベースとなる床のTransform
    [SerializeField] private Transform _floorTransform = default;

    //横移動の速さ
    private float _HorizontalMoveSpeed = 2.5f;

    //左端のポジションの値
    private float _floorLeftEdge = 0;

    //右端のポジションの値
    private float _floorRightEdge = 0;

    private const float TIME_DELTATIME_MULTIPLE = 5f;

    //オブジェクトの端を計算するとき、端より少し手前にするための変数
    private const float FLOOR_EDGE_ADJUSTMENT = 2.15f;

    private void Start()
    {
        //床の端のポジションをとる
        _floorLeftEdge = -_floorTransform.localScale.x / FLOOR_EDGE_ADJUSTMENT;
        _floorRightEdge = _floorTransform.localScale.x / FLOOR_EDGE_ADJUSTMENT;
    }

    /// <summary>
    /// 左移動の処理
    /// </summary>
    public void LeftMove(Transform playerTrandform)
    {
        //床の左端より手前なら
        if (playerTrandform.position.x > _floorLeftEdge)
        {
            //左移動
            playerTrandform.position += Vector3.left * _HorizontalMoveSpeed * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
        }
    }

    /// <summary>
    /// 右移動の処理
    /// </summary>
    public void RightMove(Transform playerTrandform)
    {
        //床の右端より手前なら
        if (playerTrandform.position.x < _floorRightEdge)
        {
            //右移動
            playerTrandform.position += Vector3.right * _HorizontalMoveSpeed * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
        }
    }
}
