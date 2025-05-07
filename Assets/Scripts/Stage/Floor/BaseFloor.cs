
public abstract class BaseFloor
{

    /// <summary>
    /// その床に到達した時、事前に床の情報から取得したいものがあれば呼び出す
    /// </summary>
    public abstract void FloorEvent(LookPlayerPointLaneFloor lookPlayerPointLaneFloor);

}
