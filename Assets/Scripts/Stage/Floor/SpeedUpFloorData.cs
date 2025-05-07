
public class SpeedUpFloorData : BaseFloor
{
    public override void FloorEvent(LookPlayerPointLaneFloor lookPlayerPointLaneFloor)
    {
        lookPlayerPointLaneFloor.JudgeOnSpeedUpFloor();
    }
}
