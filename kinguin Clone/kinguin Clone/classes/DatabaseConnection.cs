using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Threading.Tasks;

//using System.Windows.Forms;

namespace Ict4Events_WindowsForms
{
    //Bron : https://github.com/teunw/PTS2-Camping-Management-program   Dit is de klasse die is geschreven tijdens de proftaak

    /// <summary>
    /// Class for the connection to the database.
    /// </summary>
    internal sealed class DatabaseConnection
    {
        public const string databaseArgs =
            "user id=" + userName + ";password=" + password + ";data source=" + serverAddress;// + ";service name=" + servicename;

        private OracleConnection connection;
        //private const string userName = "dbi311425", password = "zqy7T4qfdD", serverAddress = "fhictora01.fhict.local", sid = "xe", servicename = "fhictora";
        private const string userName = "kinguin", password = "Password123", serverAddress = "127.0.0.1";
        //private DatabaseQueries databaseQueries;

        private static readonly DatabaseConnection _instance = new DatabaseConnection();


        public static DatabaseConnection Instance
        {
            get { return _instance; }
        }

        public OracleConnection oracleConnection
        {
            get { return connection; }
        }

        /// <summary>
        /// Gets if the database is connected
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return connection.State == ConnectionState.Open
                       || connection.State == ConnectionState.Fetching
                       || connection.State == ConnectionState.Executing;
            }
        }

        /// <summary>
        /// Gets if the connection is ready for queries
        /// </summary>
        public bool ConnectionReady
        {
            get { return connection.State == ConnectionState.Open; }
        }

        //public DatabaseQueries DatabaseQueries
        //{
        //    get { return databaseQueries; }
        //    set { databaseQueries = value; }
        //}

        public DatabaseConnection()
        {
            this.connection = new OracleConnection(databaseArgs);
        }

        /// <summary>
        /// Executes command on the database, can be used for many different things
        /// </summary>
        /// <see cref="https://msdn.microsoft.com/en-us/library/system.data.oracleclient.oraclecommand%28v=vs.110%29.aspx"/>
        /// <param name="query">Query you want to use</param>
        /// <returns>OracleCommand results for your query</returns
        public OracleCommand ExecuteCommand(string query)
        {
            OracleCommand command = new OracleCommand(query);
            command.Connection = connection;
            return command;
        }

        /// <summary>
        /// Executes a SELECT or query with result on the database
        /// </summary>
        /// <param name="query">The query you want to execute</param>
        /// <returns>OracleDataReader containing the query results, if query failed returns null</returns>
        /// <example>This example shows how to get all rows from a query
        /// <code>
        /// OracleDataReader odr = DatabaseConnection.Instance.ExecuteReadQuery("SELECT TEST FROM TEST");
        /// do
        /// {
        ///     System.Diagnostics.Debug.WriteLine(odr.GetValue(0));
        /// } while (odr.Read());
        /// </code>
        /// </example>
        public OracleDataReader ExecuteReadQuery(string query)
        {
            query = query.Replace(";", "");
            try
            {
                OpenConnection();
                OracleCommand oracleCommand = ExecuteCommand(query);
                OracleDataReader o = oracleCommand.ExecuteReader();
                return o;
            }
            catch (OracleException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Executes a prepared statement on the database, NOT TESTED YET
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">Prepared parameters for the query</param>
        /// <returns>Your query result</returns>
        public OracleDataReader ExecuteReadQuery(string query, OracleParameterCollection parameters)
        {
            OpenConnection();
            OracleCommand command = ExecuteCommand(query);

            foreach (OracleParameter op in parameters)
            {
                command.Parameters.Add(op);
            }
            command.Prepare();

            return command.ExecuteReader();
        }

        /// <summary>
        /// Query the database, can be used for queries that don't return a value
        /// </summary>
        /// <returns>Value of rows affected, -1 on statements not affecting any rows</returns>
        /// <param name="query">Query you want to execute, DONT USE SEMICOLONS (;)</param>
        /// <example>DatabaseConnection.Instance.ExecuteQuery("UPDATE SOMETHING SET KEY = VALUE")</example>
        public int ExecuteQuery(string query)
        {
            query = query.Replace(";", "");
            OracleCommand oracleCommand = ExecuteCommand(query);
            oracleCommand.CommandType = CommandType.Text;

            return oracleCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Opens connection to the database, doesn't open if connection is already open
        /// </summary>
        /// <exception cref="OracleException"/>
        /// <see cref="http://docs.oracle.com/cd/B19306_01/win.102/b14307/OracleExceptionClass.htm"/>
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (OracleException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        /// <summary>
        /// Closes connection to database if open
        /// </summary>
        /// <exception cref="OracleException"/>
        /// <see cref="http://docs.oracle.com/cd/B19306_01/win.102/b14307/OracleExceptionClass.htm"/>
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open ||
                connection.State == System.Data.ConnectionState.Connecting)
            {
                try
                {
                    connection.Close();
                }
                catch (OracleException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    throw e;
                }
            }
        }
    }
}