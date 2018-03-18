using System;
using System.Collections.Generic;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Domain
{
    public abstract class BaseDomainService<T> : IDomainService<T>
    {

        protected IDataStorage DataStorage { get; set; } 
        protected BaseDomainService(IDataStorage dataStorage)
        {
            DataStorage = dataStorage;
        }

        public abstract void Add(T model);
        public abstract void Add(IEnumerable<T> model);
        public abstract IEnumerable<T> GetAll();
    }

    public interface IDomainService<T>  : IService
    {

        void Add(T model);
        void Add(IEnumerable<T> model);
        IEnumerable<T> GetAll();

    }
    public  interface IService { }
}
