using UnityEngine;



/// <summary>
/// ゲーム開始時のムービーが終わった後の処理を管理するクラス
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

            this.GetComponent<Animator>().Play(animationName, 0, END_ANIMATION_FRAME); // 1f はアニメーションの最後のフレームを指す
            EndAnimation();
        }
    }
    /// <summary>
    /// タイトルのアニメーションが終わったら呼び出される
    /// </summary>
    public void EndAnimation()
    {
        _playSE.StopSound();
       //カメラの向きを変える
        Camera.main.transform.rotation=Quaternion.Euler(CAMERA_ROTATION_X, 0f, 0f);

        //プレイヤーだけ移動可能にする
        _gameStart.StartPlayerMove();

        this.gameObject.SetActive(false);
    }

 
}
