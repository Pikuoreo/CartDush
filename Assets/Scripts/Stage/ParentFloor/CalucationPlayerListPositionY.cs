public class CalucationPlayerListPositionY
{
    private int listNumber = 0;

    private float _groundPosition = 4;
    private float nextListPosition = 0;

    private int maxlistHeightY = 0;

    //障害物一つ分の高さの値
    private const float OBSTACLE_OBJECT_HEIGHT = 1f;

    public CalucationPlayerListPositionY(float groundPositionY, int playerListY)
    {
        //床のポジションを取得
        _groundPosition = groundPositionY;

        nextListPosition = _groundPosition;

        maxlistHeightY = playerListY;
    }

    /// <summary>
    /// プレイヤーのいるポジションを計算
    /// </summary>
    /// <returns>配列で見たとき、何番目にいるかを返す</returns>
    public int CalucationPlayerPosition(float playerPositionY)
    {
        //配列で見て、０番目の高さ、1番目の高さ、2番目の高さ・・・と見ていく
        while (listNumber < maxlistHeightY)
        {
            //配列で見て、listNumber番目の高さの上限を計算
            nextListPosition += OBSTACLE_OBJECT_HEIGHT;

            //計算した高さより低いなら
            if (playerPositionY <= nextListPosition)
            {
                //listNumber番目を返す
                break;
            }
            listNumber++;
        }

        nextListPosition = _groundPosition;

        int returnValue = listNumber;
        listNumber = 0;
        //上のfor分でReturnされなかったら、最高値の番号を返す
        return returnValue;
    }

}
