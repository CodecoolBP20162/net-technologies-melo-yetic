﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yetic_MeLo
{
    class DatabaseManager
    {
        void Execute(string query)
        {
            SqlConnection connection = new SqlConnection("YeticDatabase");
            SqlCommand command = new SqlCommand(query);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        void AddNewRowToFolderTable(string path, bool isVideo, bool isPicture, bool isMusic)
        {
            string query = "INSERT INTO Folders VALUES(" + path + "," + isVideo + "," + isPicture + "," + isMusic + ")";
            Execute(query);
        }

        void AddNewRowToSettingsTable(string category, string extension, bool check)
        {
            string query = "INSERT INTO Settings VALUES(" + category + "," + extension + "," + check + ")";            
            Execute(query);
        }
    }    
}