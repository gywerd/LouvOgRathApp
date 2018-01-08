/**************************************************************************************************
*  Author: Mads Mikkel Rasmussen (mara@aspit.dk), github: https://github.com/Mara-AspIT/          *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository:                                     *
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;

namespace LouvOgRathApp.ServerSide.DataAccess
{
    /// <summary>Executes SQL queries against a SQL Server database.</summary>
    public class Executor
    {
        #region Fields
        /// <summary>The connection string used to identify the database on a SQL Server. Is readonly. Available for read in deriving classes. Should not be inline assigned.</summary>
        protected readonly string connectionString;
        #endregion


        #region Constructors
        /// <summary>Creates a new <see cref="Executor"/> object, using the provided connection string. Should not be called from outside this namespace.</summary>
        /// <param name="connectionString">The connection string used to connect to a SQL Server.</param>
        internal Executor(string connectionString)
        {
            /* TODO: 
             1: test argument for null.
             2: make connection test logic.
             3: provide a DataAccess exception (new Execption type) if connection fails. Remember to wrap any exception in this new exception.*/
            this.connectionString = connectionString;
        }
        #endregion


        #region Methods
        /// <summary>Executes the provided SQL query. Should not be called from outside this namespace. Can be overridden.</summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <returns>A <see cref="DataSet"/> containing any data returned from the database.</returns>
        internal virtual DataSet Execute(string sql)
        {
            // TODO: Provide error handling using the DataAccess exception type.
            DataSet resultSet;
            using(SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(sql, new SqlConnection(connectionString))))
            {
                resultSet = new DataSet();
                adapter.Fill(resultSet);
            }
            return resultSet;
        } 
        #endregion
    }
}