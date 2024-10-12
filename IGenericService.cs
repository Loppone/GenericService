// IGenericService copre le funzionalità che non hanno bisogno di customizzazioni. Le Get, ad esempio, necessitano di query personalizzate.
// L'insert segue invece il paradigma Convention over Configuration: la convenzione è che le PK delle tabelle si chiamino "Id".

public interface IGenericService<T> where T : class
{
    Task<int> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
