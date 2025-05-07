using UnityEngine;

[RequireComponent(typeof(CleateFloorCleater))]
public class LookPlayerPointLaneFloor : MonoBehaviour
{
    [SerializeField] private FloorMoveSpeedChanger _floorMoveSpeedChanger = default;
    private GameObject _player = default;

    //�v���C���[�̈ʒu�̓񎟌��z��
    private int[,] PlayerList = default;

    //�v���C���[�̉����X�g�ϐ�X
    private int _playerListPointX = 0;

    private int _prePlayerListPointX = 0;

    //�v���C���[�̉����X�g�ϐ�Y
    private int _playerListPointY = 0;

    const int MAX_PLAYER_LIST_Y = 5;

    private CalucationPlayerListPositionX _calucationPlayerPositionX = default;
    private CalucationPlayerListPositionY _calucationPlayerPositionY = default;

    private LookPlayerPointLaneFloor _myScript = default;

    private BaseJump _baseJump = default;

    private PlayerPositionReset _playerPositionReset = default;

    private void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g������
        const string PLAYER_TAG = "Player";
        _player = GameObject.FindGameObjectWithTag(PLAYER_TAG);

        _playerPositionReset=new PlayerPositionReset(this.transform,_player.transform);

        //�v���C���[�ɂ��Ă���W�����v�N���X���擾
         _baseJump = _player.GetComponent<BaseJump>();

        //���g�̃N���X���擾
        _myScript = this.GetComponent<LookPlayerPointLaneFloor>();

        //�����������u�Ԃ��w��
        //�W�����v���I�������
        _baseJump._judgePlayerPosition += HandleFarAwayblock;

        InitializationPlayerPosition();
    }
    /// <summary>
    /// �v���C���[�̉����X�g�ϐ���������
    /// </summary>
    private void InitializationPlayerPosition()
    {
        //�������I�u�W�F�N�g�𐶐�����N���X���擾
       �@CleateFloorCleater cleateFloorChildren = this.GetComponent<CleateFloorCleater>();

        //���X�g�̃T�C�Y��ύX
        PlayerList = new int[cleateFloorChildren.CleaterLists.Count, MAX_PLAYER_LIST_Y];
        //X�|�W�V�������v�Z�̃N���X���C���X�^���X
        _calucationPlayerPositionX = new CalucationPlayerListPositionX(this.transform, cleateFloorChildren.CleaterLists.Count);

        //Y�|�W�V�������v�Z����N���X���C���X�^���X
        _calucationPlayerPositionY = new CalucationPlayerListPositionY(_player.transform.position.y, MAX_PLAYER_LIST_Y);

        const int HARF_LIST_LENGTH_X = 2;
        //�v���C���[�̈ʒu��z��̐^�񒆂Ƃ��Ă݂�
        _playerListPointX = Mathf.CeilToInt(PlayerList.GetLength(0) / HARF_LIST_LENGTH_X);
        _playerListPointY = 3;
    }

    /// <summary>
    /// �v���C���[�����鏰�̎�ނ�����
    /// </summary>
    public void PlayerPointJudge(int laneValue)
    {
        _calucationPlayerPositionX.LookFarAwayBrock(_player.transform.position.x);
        //���݂̃v���C���[�̈ʒu����̐^�񒆂���ǂꂮ�炢����Ă��邩������
        _playerListPointX = _calucationPlayerPositionX.PlayerListPositionX;

        _playerListPointY = _calucationPlayerPositionY.CalucationPlayerPosition(_player.transform.position.y);

        //���������������ƃv���C���[�̂���񂪈�v���Ȃ��ꍇ�A��r���Ȃ�
        //�V�̔z��Ō����Ƃ��A�v���C���[�̗񂪕ς���Ă��Ȃ��������r���Ȃ�
        if (laneValue != _playerListPointX &&
            _prePlayerListPointX == _playerListPointX)
        {
            return;
        }

        _prePlayerListPointX = _playerListPointX;

        //�t���A�ʂɋN����C�x���g���Z�b�g
        PlayerPositionLaneFloorsData.Instance.BaseFloors[_playerListPointX].FloorEvent(_myScript);
    }

    /// <summary>
    /// ��Q���ɓ����������̏���
    /// </summary>
    /// <param name="obstacleHeight">��Q���̍���</param>
    public void JudgeObstaclehit(int obstacleHeight)
    {
        if (_playerListPointY <= obstacleHeight)
        {
            _floorMoveSpeedChanger.InitializeToSpeed();
        }
    }

    /// <summary>
    /// ���Ƃ����M�~�b�N�̏��ɏ���Ă��邩�̏���
    /// </summary>
    public void JudgeOnPitFall()
    {
        //�v���C���[�̈ʒu����ԉ��������灕���_���[�W���󂯂Ă��Ȃ���Ԃ�������
        if (_playerListPointY <= 0&&!PlayerState.Instance.isDamage)
        {
            _baseJump.ChangeFalling(true);
            StartCoroutine(_playerPositionReset.IntervalResetPosition(_baseJump));
        }
    }

    /// <summary>
    /// �X�s�[�h�A�b�v�M�~�b�N�̏��ɏ���Ă��邩�̏���
    /// </summary>
    public void JudgeOnSpeedUpFloor()
    {
        if (_playerListPointY <= 0)
        {
            _floorMoveSpeedChanger.TemporarySpeedUp();
        }
    }

    /// <summary>
    /// ���̔�����J�n���郁�\�b�h���Ăяo��
    /// </summary>
    private void HandleFarAwayblock()
    {
        PlayerPointJudge(_playerListPointX);
    }
}
