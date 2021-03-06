﻿// Copyright 2012-2014 Peter Henell

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace SQLDataProducer.DataConsumers.DataToMSSSQLInsertionConsumer.DataAccess
{
    public static class CommandFactory
    {
        ///// <summary>
        ///// Create DbCommand using the configured DbFactory, the commandType will be CommandType.Text
        ///// </summary>
        ///// <param name="sqlQuery">the query to use in the command</param>
        ///// <param name="connStr">the connection string to use in the connection of the command</param>
        ///// <returns>A DbCommand with a closed connection</returns>
        //public static DbCommand Create(string query)
        //{
        //    return Create(connectionString);
        //}

        public static DbCommand CreateCommand(string sqlQuery, DbConnection conn, CommandType commandType)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandType = commandType;
            return cmd;
        }

        /// <summary>
        /// Create DbParameter using the configured DbFactory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DbParameter CreateParameter(string name, object value, SqlDbType dbType)
        {
            DbParameter param = DbProviderFactoryFactory.GetInstance().CreateParameter();
            param.Value = value;
            param.ParameterName = name;
            //param.DbType = (DbType)dbType;

            return param;
        }
        /// <summary>
        /// Create DbParameter using the configured DbFactory with null as value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DbParameter CreateParameter(string name, SqlDbType dbType)
        {
            return CreateParameter(name, System.DBNull.Value, dbType);
        }

        public static DbConnection CreateDbConnection(string connectionString)
        {
            return ConnectionFactory.Create(connectionString);
        }

        /// <summary>
        /// Factory to create DbConnections
        /// </summary>
        private static class ConnectionFactory
        {
            public static DbConnection Create(string connStr)
            {
                DbProviderFactory factory = DbProviderFactoryFactory.GetInstance();
                DbConnection conn = factory.CreateConnection();
                conn.ConnectionString = connStr;

                return conn;
            }
        }


        /// <summary>
        /// Singleton DbProviderFactory
        /// </summary>
        public static class DbProviderFactoryFactory
        {
            private static DbProviderFactory factory = null;
            private static string provider = "System.Data.SqlClient";

            public static DbProviderFactory ProviderFactory
            {
                set { factory = value; }
            }

            //public static string Provider
            //{
            //    get { return provider; }
            //    set { provider = value; }
            //}

            public static DbProviderFactory GetInstance()
            {
                if (factory == null)
                {
                    // http://msdn.microsoft.com/en-us/library/dd0w4a2z.aspx

                    // This configuration is needed if you are going to use SqlClient.
                    // If you want to use any other client like MySql then you need to modify this setting.
                    //<appSettings>
                    //  <add key="DbConnFactory" value="System.Data.SqlClient" />
                    //</appSettings>
                    ;
                    //if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["DbConnFactory"]))
                    //{
                    //    provider = System.Configuration.ConfigurationManager.AppSettings["DbConnFactory"];
                    //}
                    factory = DbProviderFactories.GetFactory(provider);
                }

                return factory;
            }
        }

        public static DataAdapter CreateSelectDataAdapter(DbCommand cmd)
        {
            var adapter = DbProviderFactoryFactory.GetInstance().CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter;
        }
    }

}
