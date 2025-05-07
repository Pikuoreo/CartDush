using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲーム中の走行距離を管理するクラス
/// </summary>
public class DistanceTraveled
{
    private Text _distanceTraveledText = default;
    private float _distanceTraveledValue = 0f;

    //スピードの値をそのまま計算したら値が大きすぎるので、１００分の１にする
    private const int FRACTION_OF_HUNDRED = 100;

    public DistanceTraveled(Text distanceTraveledText)
    {
        _distanceTraveledText = distanceTraveledText;
    }
    public void IncreaseDistanceTraveled()
    {
        _distanceTraveledValue += FloorMoveSpeedManager.Instance.FloorMoveSpeed / FRACTION_OF_HUNDRED;
        _distanceTraveledText.text = "進んだ距離"+_distanceTraveledValue.ToString("F0")+"m";
    }
}
