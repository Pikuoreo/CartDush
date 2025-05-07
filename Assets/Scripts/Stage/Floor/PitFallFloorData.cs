public class PitFallFloorData : BaseFloor
{

    public override void FloorEvent(LookPlayerPointLaneFloor lookPlayerPointLaneFloor)
    {
        lookPlayerPointLaneFloor.JudgeOnPitFall();
    }
}
