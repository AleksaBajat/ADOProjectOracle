using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace Aleksa_Bajat_PR78_2019_Projekat.Connection
{
    internal class ConnectionPooling : IDisposable
    {
        private static IDbConnection _instance = null;

        public static IDbConnection GetConnection()
        {
            if (_instance == null || _instance.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder oracleConnection = new OracleConnectionStringBuilder();

                oracleConnection.DataSource = Connection.ConnectionParameters.LOCAL_DATA_SOURCE;
                oracleConnection.UserID = Connection.ConnectionParameters.USER_ID;
                oracleConnection.Password = Connection.ConnectionParameters.PASSWORD;
                oracleConnection.Pooling = true;
                oracleConnection.MinPoolSize = 1;
                oracleConnection.MaxPoolSize = 10;
                oracleConnection.IncrPoolSize = 3;
                oracleConnection.ConnectionLifeTime = 5;
                oracleConnection.ConnectionTimeout = 30;

                _instance = new OracleConnection(oracleConnection.ConnectionString);

            }

            return _instance;
        }


        public void Dispose()
        {
            if (_instance != null)
            {
                _instance.Close();
                _instance.Dispose();
            }
        }
    }
}
