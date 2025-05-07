using UnityEngine;

public class FloorMoveSpeedChanger:MonoBehaviour
{
    [SerializeField] private AudioClip _speedUpAudio = default;
    private const float INITIALIZE_MOVE_SPEED = 0f;

    private PlaySE _playSE = default;
    private void Start()
    {
        GameUpdator.Instance.SubscribeUpdate(SpeedChangeUpdate);
        _playSE = new PlaySE();
    }
    private void SpeedChangeUpdate()
    {
        
            //進む速度が最大速度より早かったら
            if (FloorMoveSpeedManager.Instance.FloorMoveSpeed >= FloorMoveSpeedManager.Instance.MaxFloorMoveSpeed + 0.1f)
            {
                GraduallyDecelerate();
            }

            //進む速度が最低速度より遅かったら
            if (FloorMoveSpeedManager.Instance.FloorMoveSpeed <= FloorMoveSpeedManager.Instance.MaxFloorMoveSpeed - 0.1f)
            {
                GraduallyAccelerate();
            }
        
      
    }


    /// <summary>
    /// 少しずつ加速させていく処理
    /// </summary>
    private void GraduallyAccelerate()
    {
        const int ADJUSTMENT_SPEED = 2;
        FloorMoveSpeedManager.Instance.FloorMoveSpeed += Time.deltaTime / ADJUSTMENT_SPEED;
    }

    /// <summary>
    /// 少しずつ減速させていく処理
    /// </summary>
    private void GraduallyDecelerate()
    {
        const int ADJUSTMENT_SPEED = 3;
        FloorMoveSpeedManager.Instance.FloorMoveSpeed -= Time.deltaTime / ADJUSTMENT_SPEED;
    }

    /// <summary>
    /// 速度を０にする
    /// </summary>
    public void InitializeToSpeed()
    {
        if (PlayerState.Instance.isDamage)
        {
            return;
        }

        PlayerState.Instance.TakeDamageHandler();
        FloorMoveSpeedManager.Instance.FloorMoveSpeed = INITIALIZE_MOVE_SPEED;
    }

    /// <summary>
    /// ダッシュをする
    /// </summary>
    public void TemporarySpeedUp()
    {
        _playSE.PlaySound(_speedUpAudio);
        const float SPEED_UP_VALUE = 1.5f;
        FloorMoveSpeedManager.Instance.FloorMoveSpeed = FloorMoveSpeedManager.Instance.MaxFloorMoveSpeed * SPEED_UP_VALUE;
    }
}
