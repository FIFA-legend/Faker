using System;
using System.Collections.Generic;
using Faker.Generator;

namespace Faker
{
    public class FakerConfiguration
    {
        public List<ConfigurationRule> ConfigurationRules { get; }

        public FakerConfiguration()
        {
            ConfigurationRules = new List<ConfigurationRule>();
        }

        public void Add<T1, T2, T3>(System.Linq.Expressions.Expression<Func<T1, T2>> Expression)
            where T3 : Generator<T2>
        {
            Type fieldType = typeof(T2);
            Type generatorName = typeof(T3);
            string fieldName = ((System.Linq.Expressions.MemberExpression) Expression.Body).Member.Name;
            ConfigurationRule configurationRule = new ConfigurationRule(fieldType, generatorName, fieldName);
            ConfigurationRules.Add(configurationRule);
        }
    }

    public class ConfigurationRule
    {
        public Type FieldType { get; }
        public Type GeneratorName { get; }
        public string FieldName { get; }

        public ConfigurationRule(Type FieldType, Type GeneratorName, string FieldName)
        {
            this.FieldType = FieldType;
            this.GeneratorName = GeneratorName;
            this.FieldName = FieldName;
        }
    }
}