using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private AudioClip _damageSE = default;

    private Vector3 _cameraPosition;

    // 振動の強さ
    private float shakeAmount = 0.3f;

    // 振動の時間
    private float shakeDuration = 0.5f; 

    // 振動した時間
    private float shakeTime = 0f;

    //trueで振動開始
    private bool _isStartShake = false;

    //SEを流すクラス
    private PlaySE _playSE = default;

    void Start()
    {
        _cameraPosition = this.transform.position;
        _playSE = new PlaySE();
        PlayerState.Instance.SubscribeTakeDamage(StartCameraShake);
    }

    void Update()
    {
        if (_isStartShake)
        {
            if (shakeTime > 0)
            {
                // ランダムにカメラ位置を変更
                transform.position = _cameraPosition + (Vector3)Random.insideUnitCircle * shakeAmount;

                // 振動時間を減少
                shakeTime -= Time.deltaTime;
            }
            else
            {
                // 振動終了後は元の位置に戻す
                transform.position = _cameraPosition;
            }
        }
        
    }

    private void StartCameraShake()
    {
        _playSE.PlaySound(_damageSE);
        shakeTime = shakeDuration;
        _isStartShake=true;
    }
}
