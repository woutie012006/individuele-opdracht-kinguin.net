// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseConnection.cs" company="">
//   
// </copyright>
// <summary>
//   Class for the connection to the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System.Data;

using Oracle.ManagedDataAccess.Client;

#endregion

//using System.Windows.Forms;
namespace Ict4Events_WindowsForms
{
    // Bron : https://github.com/teunw/PTS2-Camping-Management-program   Dit is de klasse die is geschreven tijdens de proftaak

    /// <summary>
    /// Class for the connection to the database.
    /// </summary>
    internal sealed class DatabaseConnection
    {
        /// <summary>
        /// The database args.
        /// </summary>
        public const string databaseArgs =
            "user id=" + userName + ";password=" + password + ";data source=" + serverAddress;

                            // + ";service name=" + servicename;

        // private const string userName = "dbi311425", password = "zqy7T4qfdD", serverAddress = "fhictora01.fhict.local", sid = "xe", servicename = "fhictora";
        /// <summary>
        /// The user name.
        /// </summary>
        private const string userName = "kinguin";

        /// <summary>
        /// The password.
        /// </summary>
        private const string password = "Password123";

        /// <summary>
        /// The server address.
        /// </summary>
        private const string serverAddress = "127.0.0.1";

        // private DatabaseQueries databaseQueries;

        /// <summary>
        /// The _instance.
        /// </summary>
        private static readonly DatabaseConnection _instance = new DatabaseConnection();

        /// <summary>
        /// The connection.
        /// </summary>
        private OracleConnection connection;

        // public DatabaseQueries DatabaseQueries
        // {
        // get { return databaseQueries; }
        // set { databaseQueries = value; }
        // }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnection"/> class.
        /// </summary>
        public DatabaseConnection()
        {
            this.connection = new OracleConnection(databaseArgs);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static DatabaseConnection Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Gets the oracle connection.
        /// </summary>
        public OracleConnection oracleConnection
        {
            get
            {
                return this.connection;
            }
        }

        /// <summary>
        /// Gets if the database is connected
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return this.connection.State == ConnectionState.Open
                       || this.connection.State == ConnectionState.Fetching
                       || this.connection.State == ConnectionState.Executing;
            }
        }

        /// <summary>
        /// Gets if the connection is ready for queries
        /// </summary>
        public bool ConnectionReady
        {
            get
            {
                return this.connection.State == ConnectionState.Open;
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="OracleCommand"/>.
        /// </returns>
        public OracleCommand ExecuteCommand(string query)
        {
            OracleCommand command = new OracleCommand(query);
            command.Connection = this.connection;
            return command;
        }

        /// <summary>
        /// Executes a SELECT or query with result on the database
        /// </summary>
        /// <param name="query">
        /// The query you want to execute
        /// </param>
        /// <returns>
        /// OracleDataReader containing the query results, if query failed returns null
        /// </returns>
        /// <example>
        /// This example shows how to get all rows from a query
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
            query = query.Replace(";", string.Empty);
            try
            {
                this.OpenConnection();
                OracleCommand oracleCommand = this.ExecuteCommand(query);
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
        /// <param name="query">
        /// Query to execute
        /// </param>
        /// <param name="parameters">
        /// Prepared parameters for the query
        /// </param>
        /// <returns>
        /// Your query result
        /// </returns>
        public OracleDataReader ExecuteReadQuery(string query, OracleParameterCollection parameters)
        {
            this.OpenConnection();
            OracleCommand command = this.ExecuteCommand(query);

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
        /// <returns>
        /// Value of rows affected, -1 on statements not affecting any rows
        /// </returns>
        /// <param name="query">
        /// Query you want to execute, DONT USE SEMICOLONS (;)
        /// </param>
        /// <example>
        /// DatabaseConnection.Instance.ExecuteQuery("UPDATE SOMETHING SET KEY = VALUE")
        /// </example>
        public int ExecuteQuery(string query)
        {
            query = query.Replace(";", string.Empty);
            OracleCommand oracleCommand = this.ExecuteCommand(query);
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
            if (this.connection.State == ConnectionState.Closed)
            {
                try
                {
                    this.connection.Open();
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
            if (this.connection.State == ConnectionState.Open || this.connection.State == ConnectionState.Connecting)
            {
                try
                {
                    this.connection.Close();
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