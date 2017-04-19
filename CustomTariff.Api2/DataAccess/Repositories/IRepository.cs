using CustomTariff.Api2.DataAccess.Entities;
using System.Collections.Generic;

namespace CustomTariff.Api2.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> Select();

        List<T> Select(string commndText, params object[] parameters);

        T Get(int id);

        T Get(int id, string name);

        T Get(string commndText, params object[] parameters);

        T Update(T obj);

        T Update(T obj, string commandText, params object[] parameters);

        T Insert(T obj);

        T Insert(T obj, string commandText, params object[] parameters);

        int Delete(T obj);

        int Delete(string commandText, params object[] parameters);
    }
}