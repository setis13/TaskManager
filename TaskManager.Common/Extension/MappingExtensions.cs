using System.Linq;
using AutoMapper;

namespace TaskManager.Common.Extension {
    public static class MappingExtensions {
        /// <summary>
        ///     Method of ignor NotMapped entity's fields
        /// </summary>
        /// <typeparam name="TSource">Source entity</typeparam>
        /// <typeparam name="TDestination">Destination entity</typeparam>
        /// <param name="expression">Expression</param>
        /// <returns>Expression</returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression) {
            var sourceType = typeof (TSource);
            var destinationType = typeof (TDestination);
            var existingMaps =
                Mapper.GetAllTypeMaps().First(x => x.SourceType == sourceType && x.DestinationType == destinationType);
            foreach (var property in existingMaps.GetUnmappedPropertyNames()) {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }
    }
}