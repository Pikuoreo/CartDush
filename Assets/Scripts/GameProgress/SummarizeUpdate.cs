using UnityEngine;

/// <summary>
/// �Q�[����Update���Ǘ�����N���X
/// </summary>
public class SummarizeUpdate:MonoBehaviour
{
    //�Q�[���J�n�O�̑ҋ@���
    [SerializeField] private GameObject _startPreparationText=default;

    //true�Ńv���C���[�ȊO�̃Q�[���S�̂�Update�𗬂�
    private bool _isGameStart = false;

    //true�Ńv���C���[�̈ړ������Ɋւ���Update�𗬂�
    private bool _isStartPlayerMove = false;

    private void Update()
    {
        //�Q�[���S�̂�Update�𗬂�
        if (_isGameStart)
        {
            GameUpdator.Instance.UpdateHandler();
        }

        //�v���C���[�̈ړ��Ɋւ���Update�𗬂�
        if (_isStartPlayerMove)
        {
            GameUpdator.Instance.PlayerUpdateHandler();
        }
    }

    /// <summary>
    /// �Q�[���̊J�n�A�I����Bool�^�Ŏ󂯎��
    /// </summary>
    /// <param name="isGameStart">true�ŃQ�[���J�n�Afalse�ŃQ�[���I��</param>
    public void SetGameState(bool isGameStart)
    {
        _isGameStart = isGameStart;

        if (!_isGameStart)
        {
            _isStartPlayerMove = false;
        }
    }

    /// <summary>
    /// �v���C���[���ړ��\�ɂ���
    /// </summary>
    public void StartPlayerMove()
    {
        _isStartPlayerMove = true;
        PreparationTextDisplay();
    }

    /// <summary>
    /// �Q�[���J�n�O�̑ҋ@��ʂ�\��
    /// </summary>
    private void PreparationTextDisplay()
    {
        
        _startPreparationText.SetActive(true);
    }
}
