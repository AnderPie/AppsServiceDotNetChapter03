using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Environment;
using static System.IO.Path;
using Northwind.EntityModels;
using Microsoft.Data.SqlClient;

partial class Program
{
    public void ADOConnection()
    {
        #region Set up connection builder
        SqlConnectionStringBuilder builder = new()
        {
            InitialCatalog = "Northwind",
            MultipleActiveResultSets = true,
            Encrypt = true,
            TrustServerCertificate = true,
            ConnectTimeout = 10
        };
        builder.DataSource = ".";
        builder.IntegratedSecurity = true;
        #endregion
        #region Create and open the connection
        SqlConnection connection = new(builder.ConnectionString);
        Console.WriteLine(connection.ConnectionString);
        Console.WriteLine();
        connection.StateChange += Connection_StateChange;
        connection.InfoMessage += Connection_InfoMessage;
        #endregion
        #region Run some commands
        #endregion
        #region Output statistics
        #endregion
    }

    public void EFCoreConnection()
    {

    }

    private static void Connection_StateChange(object sender, StateChangeEventArgs e)
    {
        WriteLineInColor($"State change from {e.OriginalState} to {e.CurrentState}.");
    }

    private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        WriteLineInColor($"Info: {e.Message}.", ConsoleColor.DarkBlue);
    }


}