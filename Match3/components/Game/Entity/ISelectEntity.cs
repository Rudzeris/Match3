namespace Match3;

public interface ISelectEntity
{
    BaseEntity? FirstEntity { get; }
    BaseEntity? SecondEntity { get; }
    ClickType _clickType { get; }
}
