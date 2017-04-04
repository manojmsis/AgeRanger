using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Services
{
   public static class Mappings
    {
        /// <summary>
        /// Map a Model Entity Object to a DTO
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        public static TDestination ToDto<TSource, TDestination>(this TSource sourceObject)
          
        {
            if (sourceObject == null)
                throw new ApplicationException("NULL Source Object Specified");

            return Mapper.Map<TSource, TDestination>(sourceObject);
        }

        /// <summary>
        /// Map a Model Entity Object to a DTO
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        public static TDestination FromDto<TSource, TDestination>(this TSource sourceObject)
        {
            if (sourceObject == null)
                throw new ApplicationException("NULL Source Object Specified");

            return Mapper.Map<TSource, TDestination>(sourceObject);
        }
    }
}
