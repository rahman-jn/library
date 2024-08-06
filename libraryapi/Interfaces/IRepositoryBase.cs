namespace libraryapi.Interfaces;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
}