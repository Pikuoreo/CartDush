using UnityEngine;


/// <summary>
/// �󂯎����SE�𗬂��N���X
/// </summary>
public class PlaySE
{

    private AudioSource _audioSource = default;

   /// <summary>
   /// �C���X�^���X���������ꂽ�Ƃ��A�J�����ɂ��Ă���AudioSource���擾����
   /// </summary>
    public PlaySE()
    {
        if(!Camera.main.TryGetComponent<AudioSource>(out _audioSource))
        {
            Debug.LogError("MainCamera��AudioSource������܂���I�I�I�I");
        }
    }

    /// <summary>
    /// �󂯎����SE�𗬂�
    /// </summary>
    /// <param name="se">���ۂɗ������ʉ�</param>
    public void PlaySound(AudioClip se)
    {
        _audioSource.PlayOneShot(se);
    }

    /// <summary>
    /// �����Ă�����ʉ����~�߂�
    /// </summary>
    public void StopSound()
    {
        _audioSource.Stop();
    }
}
