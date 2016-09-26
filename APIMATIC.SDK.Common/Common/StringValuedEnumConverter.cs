/*****************************************************************************
The MIT License (MIT)

Copyright (c) 2016 APIMATIC Limited ( https://apimatic.io )

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*****************************************************************************/

using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;

namespace APIMATIC.SDK.Common
{
    public class StringValuedEnumConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The json writer</param>
        /// <param name="value">The value to write</param>
        /// <param name="serializer">The calling serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            //handle string valued enums in dictionaries
            if (value is IDictionary)
            {
                writer.WriteStartObject();
                foreach (object keyValuePair in (value as IDictionary))
                {
                    var entry = (DictionaryEntry)keyValuePair;
                    writer.WritePropertyName(entry.Key.ToString());
                    writeStringValue(writer, entry.Value);
                }
                writer.WriteEndObject();
            }
            //handle string valued enums in lists
            else if (value is IEnumerable)
            {
                writer.WriteStartArray();
                foreach (var item in (value as IEnumerable))
                {
                    writeStringValue(writer, item);
                }
                writer.WriteEndArray();
            }
            //handle string valued enums
            else
            {
                writeStringValue(writer, value);
            }
        }

        /// <summary>
        /// Loads and writes the string value against a given enum element
        /// </summary>
        /// <param name="value">The string valued enum element value</param>
        private void writeStringValue(JsonWriter writer, object value)
        {
            Type enumHelperType = loadEnumHelperType(value.GetType());
            MethodInfo enumHelperMethod = enumHelperType.GetMethod("ToValue", new[] { value.GetType() });

            object stringValue = enumHelperMethod.Invoke(null, new object[] { value });
            if (stringValue != null)
                writer.WriteValue(stringValue);
            else
                writer.WriteNull();
        }

        /// <summary>
        /// Load the enum helper class against a given enum type
        /// </summary>
        /// <param name="enumType">The enum type to locate the helper</param>
        /// <returns>Type of the helper class for the given enum type</returns>
        private static Type loadEnumHelperType(Type enumType)
        {

#if WINDOWS_UWP || DNXCORE50
            bool isNullableGeneric = enumType.GetTypeInfo().IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>);
            Assembly assembly = enumType.GetTypeInfo().Assembly;

#else
            bool isNullableGeneric = enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>);
            Assembly assembly = enumType.Assembly;
#endif
            string enumHelperClassName = string.Format("{0}Helper", isNullableGeneric ? Nullable.GetUnderlyingType(enumType).FullName : enumType.FullName);
            Type enumHelperType = assembly.GetType(enumHelperClassName);

            if (enumHelperType == null)
                throw new InvalidCastException("Unable to load enum helper for casting value");

            return enumHelperType;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The json reader</param>
        /// <param name="objectType">Type of the object to be read</param>
        /// <param name="existingValue">The existing value of object being read</param>
        /// <param name="serializer">The calling serializer</param>
        /// <returns>The object value as enum element</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    string enumStringValue = reader.Value.ToString();
                    Type enumHelperType = loadEnumHelperType(objectType);
                    MethodInfo enumHelperMethod = enumHelperType.GetMethod("ParseString", new[] { typeof(string) });
                    object parsed = enumHelperMethod.Invoke(null, new object[] { enumStringValue });
                    return parsed;
                }
            }
            catch
            {
                throw new InvalidCastException(string.Format("Unable to cast value {0} to enum type {1}", reader.Value, objectType.Name));
            }

            throw new InvalidCastException(string.Format("Unexpected token {0} when parsing enum.", reader.TokenType));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            Type toCheck = objectType;
            Type[] genericArgs = objectType.GetGenericArguments();
            if ((genericArgs != null) && (genericArgs.Length > 0))
                toCheck = genericArgs[genericArgs.Length - 1];
#if WINDOWS_UWP || DNXCORE50
            var attributes = toCheck.GetTypeInfo().GetCustomAttributes(typeof(JsonConverterAttribute), false);
#else
            var attributes = toCheck.GetCustomAttributes(typeof(JsonConverterAttribute), false);
#endif
            if ((attributes == null))
                return false;

            foreach (var converterAttrib in attributes)
            {
                if (attributes == null)
                    continue;

                foreach (var attribute in attributes)
                {
                    var converterrType = (attribute as JsonConverterAttribute).ConverterType;
                    if (converterrType.FullName.Equals(this.GetType().FullName))
                        return true;
                }
            }

            return false;
        }
    }
}
