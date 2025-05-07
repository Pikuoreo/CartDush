using UnityEngine;
using System.Collections;
using System.Diagnostics;

[RequireComponent(typeof(SelectRetry))]
public class GameOverAnimation : MonoBehaviour
{
    //�Q�[���I�[�o�[���̊Ŕ̃A�j���[�V����
    [SerializeField, Header("�Q�[���I�[�o�[���̊Ŕ̃A�j���[�V����")] private Animator _signBoardAnimation = default;

    [SerializeField, Header("�Q�[���I�[�o�[���̊�̃A�j���[�V����")] private Animator _rockAnimation = default;
    //�Q�[���I�[�o�[���̃e�L�X�g���W���������I�u�W�F�N�g
    [SerializeField,Header("�Ŕɕ\������e�L�X�g���W���������e�I�u�W�F�N�g")] private GameObject _gameOverTexts = default;

    [SerializeField] private AudioClip _gameOverSound = default;

    private PlaySE _playSE = default;
    private SelectRetry _selectRetry = default;

    private void Start()
    {
        _selectRetry = this.GetComponent<SelectRetry>();
        _playSE = new PlaySE();
    }

    /// <summary>
    /// �Q�[���I�[�o�[�̃A�j���[�V�������J�n����
    /// </summary>
    public void StartGameOverAnimation()
    {
        _rockAnimation.SetBool("isRoll", true);
        StartCoroutine(StartSignBoardAnimation());
    }

   

    private IEnumerator StartSignBoardAnimation()
    {
        const float WAIT_TIME = 1.5f;
        yield return new WaitForSeconds(WAIT_TIME);
        _signBoardAnimation.SetInteger("AnimationNumber", 1);
        StartCoroutine(DisplayGameOverText());
        _playSE.StopSound();
        _playSE.PlaySound(_gameOverSound);
        yield break;
    }

    /// <summary>
    /// �Q�[���I�[�o�[�̃e�L�X�g��\������
    /// </summary>

    private IEnumerator DisplayGameOverText()
    {
        const int WAIT_TIME = 3;
        yield return new WaitForSeconds(WAIT_TIME);
        _gameOverTexts.SetActive(true);
        _selectRetry.StartSelect();
        yield break;
    }
}
