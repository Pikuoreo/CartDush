public class CalucationPlayerListPositionY
{
    private int listNumber = 0;

    private float _groundPosition = 4;
    private float nextListPosition = 0;

    private int maxlistHeightY = 0;

    //��Q������̍����̒l
    private const float OBSTACLE_OBJECT_HEIGHT = 1f;

    public CalucationPlayerListPositionY(float groundPositionY, int playerListY)
    {
        //���̃|�W�V�������擾
        _groundPosition = groundPositionY;

        nextListPosition = _groundPosition;

        maxlistHeightY = playerListY;
    }

    /// <summary>
    /// �v���C���[�̂���|�W�V�������v�Z
    /// </summary>
    /// <returns>�z��Ō����Ƃ��A���Ԗڂɂ��邩��Ԃ�</returns>
    public int CalucationPlayerPosition(float playerPositionY)
    {
        //�z��Ō��āA�O�Ԗڂ̍����A1�Ԗڂ̍����A2�Ԗڂ̍����E�E�E�ƌ��Ă���
        while (listNumber < maxlistHeightY)
        {
            //�z��Ō��āAlistNumber�Ԗڂ̍����̏�����v�Z
            nextListPosition += OBSTACLE_OBJECT_HEIGHT;

            //�v�Z�����������Ⴂ�Ȃ�
            if (playerPositionY <= nextListPosition)
            {
                //listNumber�Ԗڂ�Ԃ�
                break;
            }
            listNumber++;
        }

        nextListPosition = _groundPosition;

        int returnValue = listNumber;
        listNumber = 0;
        //���for����Return����Ȃ�������A�ō��l�̔ԍ���Ԃ�
        return returnValue;
    }

}
