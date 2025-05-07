using UnityEngine;



/// <summary>
/// �Q�[���J�n���̃��[�r�[���I�������̏������Ǘ�����N���X
/// </summary>
public class StartMovie : MonoBehaviour
{
    [SerializeField] private AudioClip _rollSE = default;
    [SerializeField] private SummarizeUpdate _gameStart = default;
    private const int CAMERA_ROTATION_X = 10;

    const int END_ANIMATION_FRAME = 1;

    private PlaySE _playSE = default;

    private void Start()
    {
        _playSE = new PlaySE();
        _playSE.StopSound();
        _playSE.PlaySound(_rollSE);
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            const string animationName = "RollAnimation";

            this.GetComponent<Animator>().Play(animationName, 0, END_ANIMATION_FRAME); // 1f �̓A�j���[�V�����̍Ō�̃t���[�����w��
            EndAnimation();
        }
    }
    /// <summary>
    /// �^�C�g���̃A�j���[�V�������I�������Ăяo�����
    /// </summary>
    public void EndAnimation()
    {
        _playSE.StopSound();
       //�J�����̌�����ς���
        Camera.main.transform.rotation=Quaternion.Euler(CAMERA_ROTATION_X, 0f, 0f);

        //�v���C���[�����ړ��\�ɂ���
        _gameStart.StartPlayerMove();

        this.gameObject.SetActive(false);
    }

 
}
