﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Data.Common;
using EnterpriseLibrary.Data.Configuration.Fluent;

namespace EnterpriseLibrary.Common.Configuration
{
    ///<summary>
    /// Provides extensions for common database providers.
    ///</summary>
    public static partial class DatabaseProviderExtensions
    {
        ///<summary>
        /// A Sql database for use with the System.Data.SqlClient namespace.
        ///</summary>
        /// <param name="context">Configuration context</param>
        ///<returns></returns>
        /// <seealso cref="System.Data.SqlClient"/>
        public static IDatabaseSqlDatabaseConfiguration ASqlDatabase(this IDatabaseConfigurationProviders context)
        {
            return new SqlDatabaseConfigurationExtension(context);
        }

        /// <summary>
        /// A Sql CE database for use with the System.Data.SqlServerCe namespace.
        /// </summary>
        /// <param name="context">Configuration context</param>
        /// <returns></returns>   
        public static IDatabaseSqlCeDatabaseConfiguration ASqlCeDatabase(this IDatabaseConfigurationProviders context)
        {
            return new SqlCeDatabaseConfigurationExtension(context);
        }

        /// <summary>
        /// An Odbc database for use with the <see cref="System.Data.Odbc"/> namespace.
        /// </summary>
        /// <returns></returns>
        public static IOdbcDatabaseConfiguration AnOdbcDatabase(this IDatabaseConfigurationProviders context)
        {
            return new OdbcConfigurationExtension(context);
        }

        ///<summary>
        /// An Oracle database for use with the Oracle.ManagedDataAccess.Client namespace.
        ///</summary>
        ///<returns></returns>
        ///<seealso cref="Oracle.ManagedDataAccess.Client"/>
        public static IDatabaseOracleConfiguration AnOracleDatabase(this IDatabaseConfigurationProviders context)
        {
            return new OracleConfigurationExtension(context);
        }

        ///<summary>
        /// A database with the specified database provider name.
        ///</summary>
        /// <param name="context">Extension context for fluent-interface</param>
        /// <param name="providerName">The provider name to use for this database connection</param>
        ///<returns></returns>
        /// <seealso cref="DbProviderFactories"/>
        public static IDatabaseAnotherDatabaseConfiguration AnotherDatabaseType(this IDatabaseConfigurationProviders context, string providerName)
        {
            return new AnotherDatabaseConfigurationExtensions(context, providerName);
        }
    }
}