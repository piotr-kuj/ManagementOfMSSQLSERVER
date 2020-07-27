using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VisioForge.Shared.MediaFoundation.OPM;
using Microsoft;
using System.Data.Linq;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.IO;

namespace Allbasics
{
    public class SqlConn
    {
        public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        public static List<string> columns = new List<string>();
        public static string sqlToIntroduceData = "";


        public SqlConnectionStringBuilder CreatorStringbuilder(SqlConnectionStringBuilder builder)
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   // update me
            builder.UserID = "sa";              // update me
            builder.Password = "sa";      // update me
            builder.InitialCatalog = "master";

            return builder;
        }

        public static void SqlStringBuild(SqlConnectionStringBuilder builder)
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   // update me
            builder.UserID = "sa";              // update me
            builder.Password = "sa";      // update me
            builder.InitialCatalog = "master";

        }

        public static void ConnectBase()
        {
            try
            {

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   // update me
                builder.UserID = "sa";              // update me
                builder.Password = "sa";      // update me
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ConnectBase(SqlConnectionStringBuilder builder)
        {
            try
            {

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void CloseBase(SqlConnectionStringBuilder builder)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                Console.Write("Killin' connection with SQL Server ... ");
                connection.Close();
                Console.WriteLine("Done.");
            }
        }



        public static void CreateTableWithDataBase(SqlConnectionStringBuilder builder, string basename, string tablename )
        {
            //CreatorStringbuilder(builder);
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is open.");

                // Create database
                Console.Write($"Dropping database if exist and creating database '{basename}' ... ");
                String sql = $"DROP DATABASE IF EXISTS [{basename}]; CREATE DATABASE [{basename}]";
                
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database Dropd if existed and Created.");
                }

                // Create table and insert data
                Console.Write($"Creating '{tablename}' table with data, press any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine();
                StringBuilder sb = new StringBuilder();
                sb.Append($"USE {basename}; ");
                sb.Append($"CREATE TABLE {tablename} ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                {
                manualRowCreator:
                    Console.WriteLine(" Type sqlcode ...  // LIKE  - Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");

                    string tmp = Console.ReadLine(); 
                    if(!tmp.Contains(","))
                    {
                        Console.WriteLine("cannot found - ',' // try again");
                        goto manualRowCreator;
                    }
                    ///sb.Append(tmp);
                    Console.WriteLine("...");
  
                    
                    Console.WriteLine("Do you wanna introduce more rows? //  y,Y,yes,Yes or else for exit");
                    string chkstring = Console.ReadLine();
                    if (chkstring == "Y" || chkstring == "y" || chkstring == "YES" || chkstring == "yes")
                    {
                        if (!tmp.StartsWith(" "))
                        {
                            tmp = " " + tmp;
                        }
                      
                        sb.Append(tmp);
                        goto manualRowCreator;
                    }
                    else
                    {
                        if (!tmp.StartsWith(" "))
                        {
                            tmp = " " + tmp;
                        }

                        if(tmp.Contains(","))
                        {
                            //tmp.Contains(',');
                            //tmp.Replace(',', ' ');
                            tmp = tmp.TrimEnd(',');
                        }
                        sb.Append(tmp);
                        
                        Console.WriteLine("xxx -" + tmp); /// CHECKER

                        if (tmp != "); " || tmp != ");")
                        {
                            sb.Append("); ");
                        }
                        Console.WriteLine("Done.");
                        Console.ReadKey();
                    }
                }

                /*
                sb.Append(" Name NVARCHAR(50), ");
                sb.Append(" Location NVARCHAR(50), ");
                sb.Append(" Work NVARCHAR(50) ");
                sb.Append("); ");
                */

                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }

            }

        }
        public static void CreateTable(SqlConnectionStringBuilder builder, string basename, string tablename)
        {
            //CreatorStringbuilder(builder);
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is open.");

             
                String sql = $"USE [{basename}];";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database is using...");
                }

                // Create table and insert data
                Console.Write($"Creating '{tablename}' table with data, press any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine();
                StringBuilder sb = new StringBuilder();
                sb.Append($"USE {basename}; ");
                sb.Append($"CREATE TABLE {tablename} ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                {
                manualRowCreator:
                    Console.WriteLine(" Type sqlcode ...  // LIKE  - Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");

                    string tmp = Console.ReadLine();
                    if (!tmp.Contains(","))
                    {
                        Console.WriteLine("cannot found - ',' // try again");
                        goto manualRowCreator;
                    }
                    ///sb.Append(tmp);
                    Console.WriteLine("...");


                    Console.WriteLine("Do you wanna introduce more rows? //  y,Y,yes,Yes or else for exit");
                    string chkstring = Console.ReadLine();
                    if (chkstring == "Y" || chkstring == "y" || chkstring == "YES" || chkstring == "yes")
                    {
                        if (!tmp.StartsWith(" "))
                        {
                            tmp = " " + tmp;
                        }

                        sb.Append(tmp);
                        goto manualRowCreator;
                    }
                    else
                    {
                        if (!tmp.StartsWith(" "))
                        {
                            tmp = " " + tmp;
                        }

                        if (tmp.Contains(","))
                        {
                            //tmp.Contains(',');
                            //tmp.Replace(',', ' ');
                            tmp = tmp.TrimEnd(',');
                        }
                        sb.Append(tmp);

                        Console.WriteLine("xxx -" + tmp); /// CHECKER

                        if (tmp != "); " || tmp != ");")
                        {
                            sb.Append("); ");
                        }
                        Console.WriteLine("Done.");
                        Console.ReadKey();
                    }
                }

                /*
                sb.Append(" Name NVARCHAR(50), ");
                sb.Append(" Location NVARCHAR(50), ");
                sb.Append(" Work NVARCHAR(50) ");
                sb.Append("); ");
                */

                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }

            }

        }


        public static void SmartCreatorSQLCode(SqlConnectionStringBuilder builder, string basename, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                connection.Open();

                SqlCommand command = new SqlCommand($"Select * from [BankDB].[dbo].[{tablename}]", connection);
                SqlDataReader reader = command.ExecuteReader();

                var columnNames = Enumerable.Range(0, reader.FieldCount)
                        .Select(reader.GetName).ToList();

                foreach (var item in columnNames)
                {
                    Console.Write(item + "\t");
                    columns.Add(item);
                }
                string sqlToIntroduce = $"INSERT INTO [{basename}].[dbo].[{tablename}]";// (Name) VALUES (@Name);";
                
                int counter = 2;
                sqlToIntroduce = sqlToIntroduce + " (";
                foreach(var it in columns)
                {
                    if (it == "Id")
                    {

                    }
                    else
                    {
                        if(columns.Count == 1 )
                        {

                        }
                        if ( columns.Count == 2 && counter == columns.Count )
                        {
                            sqlToIntroduce = sqlToIntroduce + $"{it})";
                            //goto end;
                        }
                        else if (columns.Count > 2 && counter != columns.Count)
                        {
                            sqlToIntroduce = sqlToIntroduce + $"{it}, ";
                            //goto end;
                        }
                        if (columns.Count > 2 && columns.Count == counter)
                        {
                            sqlToIntroduce = sqlToIntroduce + $"{it})";
                            //goto end;
                        }

                        //end:
                        counter++;
                    }
                }

                sqlToIntroduce = sqlToIntroduce + $" VALUES (";
                
                counter = 2;
                foreach (var it in columns)
                {
                    if (it == "Id")
                    {

                    }
                    else
                    {
                        if (columns.Count == 1)
                        {

                        }
                        if (columns.Count == 2 && counter == columns.Count)
                        {
                            sqlToIntroduce = sqlToIntroduce + $"@{it});";
                            //goto end;
                        }
                        if (columns.Count > 2 && counter != columns.Count)
                        {
                            sqlToIntroduce = sqlToIntroduce + $"@{it}, ";
                            //goto end;
                        }
                        if (columns.Count > 2 && columns.Count == counter)
                        {
                            sqlToIntroduce = sqlToIntroduce + $"@{it}); ";
                            //goto end;
                        }

                        //end:
                        counter++;
                    }
                }

                sqlToIntroduceData = sqlToIntroduce;
                Console.WriteLine();
                Console.WriteLine(sqlToIntroduceData);
                Console.WriteLine();
            }
        }

        public static void IntroduceData(SqlConnectionStringBuilder builder, string basename, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                connection.Open();
 

                SqlCommand command = new SqlCommand($"Select * from [{basename}].[dbo].[{tablename}]", connection);
                SqlDataReader reader = command.ExecuteReader();

                var columnNames = Enumerable.Range(0, reader.FieldCount)
                        .Select(reader.GetName).ToList();

                foreach(var item in columnNames)
                {
                    Console.Write(item + "\t");
                }

                ///Console.WriteLine(columnNames);
                Console.WriteLine();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

                Console.WriteLine($"Introducing data to {tablename} ...");


                ///////////////////////////////////////////////////////////////////////
                //sql = "";
                ///////////////////////////////////////////////////////////////////////
                string intr="";
                string sql = $"INSERT INTO [{basename}].[dbo].[{tablename}] (Name) VALUES (@Name);";
                
                using (SqlCommand command2 = new SqlCommand(sql, connection))
                {
                    foreach (var it in columnNames)
                    {
                        if (it == "Id" || it == "id" || it == "ID")
                        {

                        }
                        else
                        {
                            Console.Write(it + " - ");
                            intr = Console.ReadLine();

                            //command2.Parameters.AddWithValue("@Id", it.Count()+1);
                            command2.Parameters.AddWithValue("@Name", $"{intr}");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("the function has been in operation for " + TimeCounter(connection, sql) + " seconds.");

                    int rowsAffected = command2.ExecuteNonQuery();
                    //int rowsAdded = command2.ExecuteNonQueryAsync();
                    Console.WriteLine(rowsAffected + " row(s) inserted");
                }


            }
        }

        public static void IntroduceDataWithSmartSQLCode(SqlConnectionStringBuilder builder, string basename, string tablename, string sqlcode)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                connection.Open();

               

                SqlCommand command = new SqlCommand($"Select * from [{basename}].[dbo].[{tablename}]", connection);
                SqlDataReader reader = command.ExecuteReader();

                var columnNames = Enumerable.Range(0, reader.FieldCount)
                        .Select(reader.GetName).ToList();

                foreach (var item in columnNames)
                {
                    Console.Write(item + "\t");
                }

                ///Console.WriteLine(columnNames);
                Console.WriteLine();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

                Console.WriteLine($"Introducing data to {tablename} ...");
                Console.WriteLine("Remember about types of data // cannot enter NUMBERS to NAME, and to BALANCE word,mletters");

            

                string intr;
                string typetmp="";
                using (SqlCommand command2 = new SqlCommand(sqlcode, connection))
                {
                    foreach (var it in columnNames)
                    {
                        intr = "";
                        if (it == "Id" || it == "id" || it == "ID")
                        {

                        }
                        else
                        {
                            if(it.GetType().ToString().Replace("System.", "") == "String")
                            {
                                 typetmp = "Text";
                            }
                            if (it.GetType().ToString().Replace("System.", "") == "Int" || it.GetType().ToString().Replace("System.", "") == "Double"
                               || it.GetType().ToString().Replace("System.", "") == "Float" || it.GetType().ToString().Replace("System.", "") == "Decimal")
                            {
                                typetmp = "Number";
                            }
                           
                            Console.Write(it +/* " - " + typetmp + */" : ");
                            //Console.Write(it.GetType() + " " + it);
                            intr = Console.ReadLine();

                            command2.Parameters.AddWithValue($"@{it}", $"{intr}");
                        }
                    }

                    
                    int rowsAffected = command2.ExecuteNonQuery();
                    //int rowsAdded = command2.ExecuteNonQueryAsync();
                    Console.WriteLine(rowsAffected + " row(s) inserted");
                }



            }
        }


        public static void DeleteData(SqlConnectionStringBuilder builder, string basename, string tablename, int id)
        {
            Console.WriteLine();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();

                string sql = $"DELETE FROM [{basename}].[dbo].[{tablename}] WHERE Id = {id};";
                ///String userToDelete = "Jared";

                Console.Write("Deleting user with id - '" + id + "', press any key to continue...");
                Console.ReadKey(true);
                sb.Clear();
                sb.Append($"DELETE FROM [{basename}].[dbo].[{tablename}] WHERE Id = {id};");
                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) deleted");
                }


            }

        }

        public static void UpdateData_OneColumn(SqlConnectionStringBuilder builder, string basename, string tablename, int id, string column, string newdata)
        {
            Console.WriteLine();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();

                String sql = $"UPDATE [{basename}].[dbo].[{tablename}] SET {column} = N'{newdata}' WHERE Id = {id};";// SET {column} = {newdata} WHERE Id = {id};"; //UPDATE table_name

                Console.Write($"Updating '{column}' with value: '" + newdata + "', press any key to continue...");
                Console.ReadKey(true);
                
                sb.Clear();
                sb.Append($"UPDATE [{basename}].[dbo].[{tablename}] SET {column} = N'{newdata}' WHERE Id = {id};");
                sql = sb.ToString();
                
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    TimeCounter(connection, sql);
                    command.Parameters.AddWithValue($"@{id}", newdata);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) updated");
                }

            }

        }

        public static void ReadData(SqlConnectionStringBuilder builder, string basename, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                connection.Open();


                SqlCommand command = new SqlCommand($"Select * from [BankDB].[dbo].[{tablename}]", connection);
                SqlDataReader reader = command.ExecuteReader();

                var columnNames = Enumerable.Range(0, reader.FieldCount)
                        .Select(reader.GetName) //OR .Select("\""+  reader.GetName"\"") 
                        .ToList();

                ///Console.WriteLine(reader.GetValue(reader.GetOrdinal("ColumnID")));

                foreach (var item in columnNames)
                {
                    Console.Write(item + "\t");
                }

                ///Console.WriteLine(columnNames);
                Console.WriteLine();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

            }
        }


        public static double TimeCounter(SqlConnection connection, string sql)
        {
            
            long startTicks = DateTime.Now.Millisecond;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                try
                {
                    var sum = command.ExecuteScalar();
                    TimeSpan elapsed = TimeSpan.FromTicks(DateTime.Now.Millisecond) - TimeSpan.FromTicks(startTicks);
                    Console.WriteLine();
                    Console.WriteLine("the function has been in operation for " + elapsed.TotalMilliseconds + " secounds.");
                    return elapsed.TotalMilliseconds;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return 0;
        }




    }

    public class SqlBackup
    {
        SqlConnectionStringBuilder backupBuilder = new SqlConnectionStringBuilder();
        //static DateTime time = DateTime.Now;
        //public string stime = time.ToString("yyyy-MM-dd-HH-mm-tt");
        public static string path = @"C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\";
        public static string path2 = @"C:/Program Files/Microsoft SQL Server/MSSQL14.SQLSERVER/MSSQL/DATA/";
        public static string nameOfLastestBackup;
        public static string pathWithFile; // = path + nameOfLastestBackup;

        public static void BackUpDataBase(SqlConnectionStringBuilder builder, string basename)
        {
            Console.WriteLine();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                
                ///String sql = $"DROP DATABASE IF EXISTS [{basename}]; CREATE DATABASE [{basename}]";
                string sql = $"BACKUP DATABASE[{basename}] TO DISK = 'C:/Program Files/Microsoft SQL Server/MSSQL14.SQLSERVER/MSSQL/DATA/backup{DateTime.Now.ToShortDateString()}.mdf' ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database Backup successful");
                }
            }
        }

        // TEST FOR RESTORE AND BACKUP VOIDS
        public static void DeleteDataBase(SqlConnectionStringBuilder builder, string basename)
        {
            Console.WriteLine();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                Console.Write($"Dropping - {basename} database if exist ");
                String sql = $"DROP DATABASE IF EXISTS [{basename}];";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database Dropd");
                }
            }
        }

        public static void RestoreDataBase(SqlConnectionStringBuilder builder, string basename, string maindatabase, string pth)
        { 
            Console.WriteLine();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                Console.Write($"Restoring - {maindatabase} database if doesnt exist ");

                string sql = $"RESTORE DATABASE [{maindatabase}] FROM DISK='{pathWithFile}'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    
                    Console.WriteLine("Database restored");
                }
            }

        }

        public static void RestoreDataBase(SqlConnectionStringBuilder builder, string basename, string pth)
        {
            Console.WriteLine();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                Console.Write($"Restoring - {basename} database if doesnt exist ");
                string sql = $"RESTORE DATABASE [{basename}] FROM DISK='{pth}' WITH RECOVERY";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database restored");
                }
            }

        }




        public static string Help_DataBase_FilesnameOfPath()
        {
            // -  C:/ Program Files / Microsoft SQL Server/ MSSQL14.SQLSERVER / MSSQL / DATA / backup{ DateTime.Now.ToShortDateString()}.mdf' ";
            string path = @"C:/Program Files/Microsoft SQL Server/MSSQL14.SQLSERVER/MSSQL/DATA/";
            string tmp ="                    ";
            string tmpbu = tmp;

            string rstring= "                      ";
           
            Console.WriteLine();

            DirectoryInfo dbDirectory = new DirectoryInfo(path);
            FileInfo[] UninstallerFiles = dbDirectory.GetFiles();
            Console.WriteLine("Listing all files");


            foreach (FileInfo files in UninstallerFiles)
            {
                Console.WriteLine(files.Name.ToString());

                if (files.Name.ToString().Contains("backup"))
                {
                    tmp = files.Name.ToString();
                    if(tmp[12] >= tmpbu[12] )//&& tmp[10] > tmpbu[10] && tmp[10] > tmpbu[10] && () )
                    {
                        if(tmp[13] >= tmpbu[13])
                        {
                            if (tmp[14] >= tmpbu[14])
                            {
                                if (tmp[15] >= tmpbu[15])
                                {
                                    if (tmp[9] >= tmpbu[9])
                                    {
                                        if (tmp[10] >= tmpbu[10])
                                        {
                                            if (tmp[6] >= tmpbu[6])
                                            {
                                                if (tmp[7] >= tmpbu[7])
                                                {
                                                    rstring = tmp;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }     
                    }
                    //b[0] a[1] c[2] k[3]u [4] p[5]   0[6] 7[7] .[8]  0[9] 4[10]  .[11]  2[12] 0[13] 2[14] 0[15]

                    tmpbu = tmp;
                }

            }
            Console.WriteLine();
            //ReturnPath(filepath, rstring);
            nameOfLastestBackup = rstring;
            pathWithFile = path + nameOfLastestBackup;
            return rstring;
        }

        public static string ReturnPath(string a, string b)
        {
            a = b;
            return a;
        }




    }
}
