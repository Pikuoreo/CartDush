using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private AudioClip _damageSE = default;

    private Vector3 _cameraPosition;

    // �U���̋���
    private float shakeAmount = 0.3f;

    // �U���̎���
    private float shakeDuration = 0.5f; 

    // �U����������
    private float shakeTime = 0f;

    //true�ŐU���J�n
    private bool _isStartShake = false;

    //SE�𗬂��N���X
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
                // �����_���ɃJ�����ʒu��ύX
                transform.position = _cameraPosition + (Vector3)Random.insideUnitCircle * shakeAmount;

                // �U�����Ԃ�����
                shakeTime -= Time.deltaTime;
            }
            else
            {
                // �U���I����͌��̈ʒu�ɖ߂�
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
