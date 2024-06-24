using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kendo.Mvc.Examples.Tools
{
    public class DbExporter
    {
        public void ExportToJson(DbContext dbContext, string path)
        {
            var dbType = dbContext.GetType();
            var dbSets = dbType.GetProperties().Where(x => x.PropertyType.Name.ToLower().Contains("dbset"));
            var tableNames = dbSets.Select(x => x.Name);
            var exportMethod = this.GetType().GetMethod("ExportToJSON");

            foreach (var tableName in tableNames)
            {
                var dbSet = dbType.GetProperty(tableName).GetValue(dbContext);
                var dbSetGenericType = dbSet.GetType().GetGenericArguments();

                var method = exportMethod.MakeGenericMethod(dbSetGenericType);
                method.Invoke(this, new[] { dbSet, tableName, path });
            }
        }

        public void ExportDbSetToJSON<T>(DbSet<T> dbSet, string name, string path) where T : class
        {
            var data = dbSet.ToList().Select(MapToObject).ToList();
            var json = JsonConvert.SerializeObject(new { data = data });

            System.IO.File.AppendAllText(path + name + ".json", json);

        }

        private Dictionary<string, object> MapToObject(object obj)
        {
            var result = new Dictionary<string, object>();
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(obj);
                var isCollection = typeof(ICollection).IsAssignableFrom(prop.PropertyType);
                var isPrimitive = prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string);
                var genericParameters = prop.PropertyType.GetGenericArguments();
                var hasGenericParameters = genericParameters.Length > 0;


                if (isPrimitive || (isCollection && !hasGenericParameters))
                {
                    result[prop.Name] = propValue;
                }

                if (isCollection && hasGenericParameters)
                {
                    var mapMethod = this.GetType().GetMethods().FirstOrDefault(x => x.Name.Contains("MapCollection"));
                    var method = mapMethod.MakeGenericMethod(genericParameters);
                    var val = method.Invoke(this, new[] { propValue });

                    result[prop.Name] = val;
                }
            }

            return result;
        }

        public IEnumerable<object> MapCollection<T>(IEnumerable<T> collection)
        {
            var mapped = collection.Select(x => MapToObject(x));
            return mapped;
        }
    }
}