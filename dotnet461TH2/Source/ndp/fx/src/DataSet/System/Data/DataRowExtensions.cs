//------------------------------------------------------------------------------
// <copyright file="DataRowExtenstions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <owner current="true" primary="true">[....]</owner>
// <owner current="true" primary="false">spather</owner>
//------------------------------------------------------------------------------
using System;
using System.Data.DataSetExtensions;

namespace System.Data {
    
    /// <summary>
    /// This static class defines the DataRow extension methods.
    /// </summary>
    public static class DataRowExtensions {
    
        /// <summary>
        ///  This method provides access to the values in each of the columns in a given row. 
        ///  This method makes casts unnecessary when accessing columns. 
        ///  Additionally, Field supports nullable types and maps automatically between DBNull and 
        ///  Nullable when the generic type is nullable. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow
        /// </param>
        /// <param name="columnName">
        ///   The input column name specificy which row value to retrieve.
        /// </param>
        /// <returns>
        ///   The DataRow value for the column specified.
        /// </returns> 
        public static T Field<T>(this DataRow row, string columnName) {
            DataSetUtil.CheckArgumentNull(row, "row");
            return UnboxT<T>.Unbox(row[columnName]);
        }
        
        /// <summary>
        ///  This method provides access to the values in each of the columns in a given row. 
        ///  This method makes casts unnecessary when accessing columns. 
        ///  Additionally, Field supports nullable types and maps automatically between DBNull and 
        ///  Nullable when the generic type is nullable. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow
        /// </param>
        /// <param name="column">
        ///   The input DataColumn specificy which row value to retrieve.
        /// </param>
        /// <returns>
        ///   The DataRow value for the column specified.
        /// </returns> 
        public static T Field<T>(this DataRow row, DataColumn column) {
            DataSetUtil.CheckArgumentNull(row, "row");
            return UnboxT<T>.Unbox(row[column]);
        }

        /// <summary>
        ///  This method provides access to the values in each of the columns in a given row. 
        ///  This method makes casts unnecessary when accessing columns. 
        ///  Additionally, Field supports nullable types and maps automatically between DBNull and 
        ///  Nullable when the generic type is nullable. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow
        /// </param>
        /// <param name="columnIndex">
        ///   The input ordinal specificy which row value to retrieve.
        /// </param>
        /// <returns>
        ///   The DataRow value for the column specified.
        /// </returns> 
        public static T Field<T>(this DataRow row, int columnIndex) {
            DataSetUtil.CheckArgumentNull(row, "row");
            return UnboxT<T>.Unbox(row[columnIndex]);
        }

        /// <summary>
        ///  This method provides access to the values in each of the columns in a given row. 
        ///  This method makes casts unnecessary when accessing columns. 
        ///  Additionally, Field supports nullable types and maps automatically between DBNull and 
        ///  Nullable when the generic type is nullable. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow
        /// </param>
        /// <param name="columnIndex">
        ///   The input ordinal specificy which row value to retrieve.
        /// </param>
        /// <param name="version">
        ///   The DataRow version for which row value to retrieve.
        /// </param>
        /// <returns>
        ///   The DataRow value for the column specified.
        /// </returns> 
        public static T Field<T>(this DataRow row, int columnIndex, DataRowVersion version) {
            DataSetUtil.CheckArgumentNull(row, "row");
            return UnboxT<T>.Unbox(row[columnIndex, version]);
        }

        /// <summary>
        ///  This method provides access to the values in each of the columns in a given row. 
        ///  This method makes casts unnecessary when accessing columns. 
        ///  Additionally, Field supports nullable types and maps automatically between DBNull and 
        ///  Nullable when the generic type is nullable. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow
        /// </param>
        /// <param name="columnName">
        ///   The input column name specificy which row value to retrieve.
        /// </param>
        /// <param name="version">
        ///   The DataRow version for which row value to retrieve.
        /// </param>
        /// <returns>
        ///   The DataRow value for the column specified.
        /// </returns> 
        public static T Field<T>(this DataRow row, string columnName, DataRowVersion version) {
            DataSetUtil.CheckArgumentNull(row, "row");
            return UnboxT<T>.Unbox(row[columnName, version]);
        }

        /// <summary>
        ///  This method provides access to the values in each of the columns in a given row. 
        ///  This method makes casts unnecessary when accessing columns. 
        ///  Additionally, Field supports nullable types and maps automatically between DBNull and 
        ///  Nullable when the generic type is nullable. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow
        /// </param>
        /// <param name="column">
        ///   The input DataColumn specificy which row value to retrieve.
        /// </param>
        /// <param name="version">
        ///   The DataRow version for which row value to retrieve.
        /// </param>
        /// <returns>
        ///   The DataRow value for the column specified.
        /// </returns> 
        public static T Field<T>(this DataRow row, DataColumn column, DataRowVersion version) {
            DataSetUtil.CheckArgumentNull(row, "row");
            return UnboxT<T>.Unbox(row[column, version]);
        }

        /// <summary>
        ///  This method sets a new value for the specified column for the DataRow it?s called on. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow.
        /// </param>
        /// <param name="columnIndex">
        ///   The input ordinal specifying which row value to set.
        /// </param>
        /// <param name="value">
        ///   The new row value for the specified column.
        /// </param>
        public static void SetField<T>(this DataRow row, int columnIndex, T value) {
            DataSetUtil.CheckArgumentNull(row, "row");
            row[columnIndex] = (object)value ?? DBNull.Value;
        }
        
        /// <summary>
        ///  This method sets a new value for the specified column for the DataRow it?s called on. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow.
        /// </param>
        /// <param name="columnName">
        ///   The input column name specificy which row value to retrieve.
        /// </param>
        /// <param name="value">
        ///   The new row value for the specified column.
        /// </param>
        public static void SetField<T>(this DataRow row, string columnName, T value) {
            DataSetUtil.CheckArgumentNull(row, "row");
            row[columnName] = (object)value ?? DBNull.Value;
        }

        /// <summary>
        ///  This method sets a new value for the specified column for the DataRow it?s called on. 
        /// </summary>
        /// <param name="row">
        ///   The input DataRow.
        /// </param>
        /// <param name="column">
        ///   The input DataColumn specificy which row value to retrieve.
        /// </param>
        /// <param name="value">
        ///   The new row value for the specified column.
        /// </param>
        public static void SetField<T>(this DataRow row, DataColumn column, T value) {
            DataSetUtil.CheckArgumentNull(row, "row");
            row[column] = (object)value ?? DBNull.Value;
        }

        private static class UnboxT<T>
        {
            internal static readonly Converter<object, T> Unbox = Create(typeof(T));

            private static Converter<object, T> Create(Type type)
            {
                if (type.IsValueType)
                {
                    if (type.IsGenericType && !type.IsGenericTypeDefinition && (typeof(Nullable<>) == type.GetGenericTypeDefinition()))
                    {
                        return (Converter<object, T>)Delegate.CreateDelegate(
                            typeof(Converter<object, T>),
                                typeof(UnboxT<T>)
                                    .GetMethod("NullableField", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                                    .MakeGenericMethod(type.GetGenericArguments()[0]));
                    }
                    return ValueField;
                }
                return ReferenceField;
            }

            private static T ReferenceField(object value)
            {
                return ((DBNull.Value == value) ? default(T) : (T)value);
            }

            private static T ValueField(object value)
            {
                if (DBNull.Value == value)
                {
                    throw DataSetUtil.InvalidCast(Strings.DataSetLinq_NonNullableCast(typeof(T).ToString()));
                }
                return (T)value;
            }

            private static Nullable<TElem> NullableField<TElem>(object value) where TElem : struct
            {
                if (DBNull.Value == value)
                {
                    return default(Nullable<TElem>);
                }
                return new Nullable<TElem>((TElem)value);
            }
        }
    }
}
