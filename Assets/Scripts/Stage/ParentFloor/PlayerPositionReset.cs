using UnityEngine;
using System.Collections;

public class PlayerPositionReset
{
    private Transform _playerTransform = default;
    private Transform _thisTransform = default;

    private const float PLAYER_SPAWN_POINT_Y = 1.5f;
    private float _playerSpawnPointZ = 4.9f;
    const float SPAWN_POSITION_ADJUSTMENT = 2.2f;

    private FloorMoveSpeedChanger _floorSpeedChanger = default;

    /// <summary>
    /// 自分自身のTransformとプレイヤーのTransformコンポーネントを取得
    /// </summary>
    /// <param name="thisTransform"></param>
    /// <param name="playerTransform"></param>
    public PlayerPositionReset(Transform thisTransform,Transform playerTransform)
    {
        _thisTransform = thisTransform;
        _playerTransform = playerTransform;

        //Zの値を自分の端っこより少し手前にする
        _playerSpawnPointZ = thisTransform.localScale.z / SPAWN_POSITION_ADJUSTMENT;

        _floorSpeedChanger = Object.FindFirstObjectByType<FloorMoveSpeedChanger>();

        InitializationPosition();
    }

    private void InitializationPosition()
    {
        //プレイヤーを端っこに移動させる
        _playerTransform.position = _thisTransform.position + new Vector3(0, PLAYER_SPAWN_POINT_Y, -_playerSpawnPointZ);
       
    }

    public IEnumerator IntervalResetPosition(BaseJump baseJump)
    {
        yield return new WaitForSeconds(1);
        baseJump.ChangeFalling(false);
        _floorSpeedChanger.InitializeToSpeed();
        InitializationPosition();
    }
}
