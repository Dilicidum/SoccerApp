using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Application.MappingProfiles
{
    public class ResourceToModel:Profile
    {
        public ResourceToModel()
        {
            
                
                
        }

        public static Expression<Func<TEntity, string>> CreateEnumShortNameExpression<TEntity, TEnum>
            (Expression<Func<TEntity, TEnum>> propertyExpression)
        where TEntity : class
        where TEnum : struct
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<Enum>();
            Expression resultExpression = Expression.Constant(string.Empty);
            foreach (var enumValue in enumValues)
            {
                resultExpression = Expression.Condition(
                    Expression.Equal(propertyExpression.Body, Expression.Constant(enumValue)),
                    Expression.Constant(EnumHelper.GetShortName(enumValue)),
                    resultExpression);
            }

            return Expression.Lambda<Func<TEntity, string>>(resultExpression, propertyExpression.Parameters);
        }
    }
}
