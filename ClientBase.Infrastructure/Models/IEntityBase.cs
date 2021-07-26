namespace ClientBase.Infrastructure.Models
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}
