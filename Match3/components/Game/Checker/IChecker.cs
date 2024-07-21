namespace Match3
{
    public interface IChecker
    {
        CheckResult CheckCells(BaseEntity baseEntity, out List<BaseEntity> list);
    }
}
