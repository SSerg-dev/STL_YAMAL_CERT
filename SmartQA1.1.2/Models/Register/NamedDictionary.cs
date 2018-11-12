using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.Models.Register
{
    public class NamedDictionary<TKey, TValue, TModel> : Dictionary<TKey, TValue>
    {
        public string keyName = null;
        public string valueName = null;

        public NamedDictionary(string keyName, string valueName)
        {
            this.keyName = keyName;
            this.valueName = valueName;
        }

        public NamedDictionary(string keyName, string valueName, List<TModel> modelList) : base()
        {
            this.keyName = keyName;
            this.valueName = valueName;

            if (modelList != null)
            {
                var modelType = modelList[0].GetType();

                var modelKeyType = modelType.GetProperty(keyName);
                if (modelKeyType == null)
                    throw new ArgumentException(
                        "Not valid keyName specified for model: " + modelType + " keyName: " + keyName);

                var modelValueType = modelType.GetProperty(valueName);
                if (modelValueType == null)
                    throw new ArgumentException(
                        "Not valid valueName specified for model: " + modelType + " valueName: " + valueName);

                foreach (var model in modelList)
                {
                    TKey key;
                    TValue value;
                    try
                    {
                        key = (TKey) modelKeyType.GetValue(model);
                    }
                    catch (InvalidCastException ice)
                    {
                        throw new InvalidCastException("Not valid type specified for key parameter");
                    }
                    try
                    {
                        value = (TValue) modelValueType.GetValue(model);
                    }
                    catch (InvalidCastException ice)
                    {
                        throw new InvalidCastException("Not valid type specified for value parameter");
                    }
                    Add(key, value);
                }
            }
            else throw new ArgumentNullException("modelList is null");
        }
    }
}