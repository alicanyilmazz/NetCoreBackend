using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdded(string key);
        void Remove(string key);

        /// <summary>
        /// ServiceName.MethodName
        /// <example>
        ///<code>
        /// IProductService.Get,ICategoryService.Get...
        /// </code>
        /// </example>
        /// *IProductService.Get* deletes keys that contain
        /// <example>
        ///<code>
        /// IProductService.GetListByCategory,IProductService.GetById,IProductService.GetList
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="pattern"> Service Interface Name . Method Name </param>
        void RemoveByPattern(string pattern);
    }
}
