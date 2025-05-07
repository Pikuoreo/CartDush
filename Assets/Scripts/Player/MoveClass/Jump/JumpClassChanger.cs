using UnityEngine;

/// <summary>
/// �A�C�e���擾�ȂǁA�󋵂ɂ���ăW�����v�������Ǘ�����N���X��ς���N���X
/// </summary>
public class JumpClassChanger : MonoBehaviour
{
   �@//���݂̃W�����v����
    public BaseJump CurrentJumpClass { get; private set; }

    private void Start()
    {
        //�ŏ���DeafultJump���Z�b�g����
        CurrentJumpClass = gameObject.AddComponent<DefaultJump>();
    }

    /// <summary>
    /// �W�����v�����̃N���X��ύX����
    /// </summary>
    /// <typeparam name="T">�ύX����BaseJump���p�������W�����v�����̃N���X</typeparam>
    public void ChangeJumpType<T>() where T : BaseJump
    {
        //���łɕʂ̃W�����v����������ꍇ
        if (CurrentJumpClass != null)
        {
            //�����Ă���W�����v�������폜
            Destroy(CurrentJumpClass);
        }

        //�V�����W�����v�����̃N���X��ǉ�
        CurrentJumpClass = gameObject.AddComponent<T>();
    }

}
