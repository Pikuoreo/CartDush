using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーを追いかける側（ゲームオーバーゾーン）の距離を管理するクラス
/// </summary>
public class ChaserPlayer : MonoBehaviour
{
    [SerializeField,Header("岩との距離テキスト")] private Text _distanceText = default;
    [SerializeField,Header("リザルトの走行距離テキスト")] private Text _distanceTraveledText = default;

    //ゲームオーバーになるまでの距離
    public float DisTance
    {
        get; private set;
    }

    //プレイヤーに近づいていく速さ
    private float _closerSpeed = 2.7f;

    //経過時間
    private float _elapsedTime = 0f;

    //次レベルアップするまでの時間
    private float _levelUpTime = 8;

    //近づく側、進む側のスピードを比べて離れている距離の計算に使う
    //スピードの値をそのまま計算したら値が大きすぎるので、１００分の１にする
    private const int FRACTION_OF_HUNDRED = 100;

    //次のレベルアップするまでの追加時間
    private const float NEXT_LEVEL_UP_TIME = 0.25f;

    //ゲーム開始時のプレイヤーと離れている距離
    private const float START_DISTANCE_VALUE = 200f;

    private DistanceTraveled _distanceTraveled=default;
    private void Start()
    {
        DisTance = START_DISTANCE_VALUE;
        GameUpdator.Instance.SubscribeUpdate(ChaserPlayerUpdate);

        _distanceTraveled=new DistanceTraveled(_distanceTraveledText);
    }
    void ChaserPlayerUpdate()
    {
            DistanceUpdate();
            _distanceTraveled.IncreaseDistanceTraveled();
    }

    /// <summary>
    /// 経過時間ごとに追いかけるスピード、進むスピードを早くする
    /// </summary>
    private void DifficultyLevelUp()
    {
        //経過時間
        _elapsedTime += Time.deltaTime;

        //もし経過時間がレベルアップまでの時間を超えたら
        if (_elapsedTime > _levelUpTime)
        {

            //経過時間をリセット
            _elapsedTime = 0;

            //次のレベルアップまでの時間を少し長くする
            _levelUpTime += NEXT_LEVEL_UP_TIME;

            const float CLOSER_SPEED_UP_VALUE = 0.1f;
            //近づくスピードを早める
            _closerSpeed += CLOSER_SPEED_UP_VALUE;

            const float MOVE_SPEED_UP_VALUE = 0.04f;
            //プレイヤーの進むスピードを早める
            FloorMoveSpeedManager.Instance.FloorMoveSpeed += MOVE_SPEED_UP_VALUE;
        }
    }

    /// <summary>
    /// プレイヤーとの距離を更新
    /// </summary>
    private void DistanceUpdate()
    {
        //追いかける側のスピード分を引き、プレイヤーが進むスピード分を足す
        //結果、プレイヤーとどれくらい離れているかを計算
        DisTance -= _closerSpeed / FRACTION_OF_HUNDRED;
        DisTance += FloorMoveSpeedManager.Instance.FloorMoveSpeed / FRACTION_OF_HUNDRED;

        const string DISTANCE = "岩との距離：";
        const string METER = "m";
        //テキストの更新
        _distanceText.text = DISTANCE + DisTance.ToString("F0")+METER;

        DifficultyLevelUp();
    }
}
