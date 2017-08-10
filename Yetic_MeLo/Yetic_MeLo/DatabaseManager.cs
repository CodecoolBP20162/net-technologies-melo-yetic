using System;
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

        // Folders Table
        void AddNewRowToFolderTable(string path, bool isVideo, bool isPicture, bool isMusic)
        {
            string query = "INSERT INTO Folders VALUES('" + path + "','" + isVideo + "','" + isPicture + "','" + isMusic + "')";
            Execute(query);
        }

        void UpdateFolderTable(int id, string path, bool isVideo, bool isPicture, bool isMusic)
        {
            string query = "UPDATE Folder SET Path = '" + path + "', isVideo = '" + isVideo + "', isPicture = '" + isPicture + "', isMusic = '" + isMusic + "' WHERE Id = " + id + ";";
            Execute(query);
        }


        // Settings Table
        void AddNewRowToSettingsTable(string category, string extension, bool check)
        {
            string query = "INSERT INTO Settings VALUES('" + category + "','" + extension + "','" + check + "')";            
            Execute(query);
        }

        void UpdateSettingsTable(int id, string category, string extension, bool check)
        {
            string query = "UPDATE Folder SET Category = '" + category + "', Extension = '" + extension + "', Check = '" + check + "' WHERE Id = " + id + ";";
            Execute(query);
        }


        // Delete Row
        void DeleteRowFromTable(string table, int id)
        {
            string query = "DELETE FROM" + table + "WHERE Id ='" + id.ToString() + "';";
            Execute(query);
        }
    }    
}
