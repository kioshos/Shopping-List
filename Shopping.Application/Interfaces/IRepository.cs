namespace Shopping.Application.Interfaces;

public interface IRepository<T>
{
    List<T> GetAll();
    
    T Add(T entity);
    T Update(T entity);
    T Delete(int id);
    T GetById(int id);
}