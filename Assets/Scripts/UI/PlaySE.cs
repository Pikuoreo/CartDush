using UnityEngine;


/// <summary>
/// 受け取ったSEを流すクラス
/// </summary>
public class PlaySE
{

    private AudioSource _audioSource = default;

   /// <summary>
   /// インスタンスが生成されたとき、カメラについているAudioSourceを取得する
   /// </summary>
    public PlaySE()
    {
        if(!Camera.main.TryGetComponent<AudioSource>(out _audioSource))
        {
            Debug.LogError("MainCameraにAudioSourceがありません！！！！");
        }
    }

    /// <summary>
    /// 受け取ったSEを流す
    /// </summary>
    /// <param name="se">実際に流す効果音</param>
    public void PlaySound(AudioClip se)
    {
        _audioSource.PlayOneShot(se);
    }

    /// <summary>
    /// 流している効果音を止める
    /// </summary>
    public void StopSound()
    {
        _audioSource.Stop();
    }
}
