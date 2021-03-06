﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Services.DataBase
{
    public static class DataBaseServices
    {
        public static readonly string VendingMachineTableName = "VendingMachineTable";
        public static readonly string CartItemTableName = "CartItemTable";
        public static readonly string CustomerSessionTableName = "CustomerSessionTable";
        public static readonly string LocationTableName = "LocationTable";
        public static readonly string SellItemTableName = "SellItemTable";
        public static readonly string UserTableName = "UserTable";
        public static readonly string CellTableName = "CellTable";

        #region Methods

        public static string GetConnectionIdentifier()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["SqlDefault"].ConnectionString;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs<T>(T model, bool isIdIncluded = false) where T : ITable
        {
            List<KeyValuePair<string, object>> properities = new List<KeyValuePair<string, object>>();

            PropertyInfo[] publicProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in publicProps)
            {
                if (!isIdIncluded)
                {
                    if (prop.Name == "Id")
                    {
                        continue;
                    }
                }
                properities.Add(new KeyValuePair<string, object>(prop.Name, prop.GetValue(model)));
            }
            return properities;
        }

        public static string GetTableName<T>(T model) where T : ITable
        {
            if (model == null)
            {
                model = default;
            }
            string name = typeof(T).Name;
            return name.Substring(0, name.Length - "Record".Length);
        }

        #endregion Methods
    }
}