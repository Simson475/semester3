using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core
{
    public class UserDatabase
    {
        public UserDatabase() { }
        public List<User> Users { get; set; } = new List<User>();
        public string Path { get; set; } = "../../../ImportFiles\\users.csv";

        /// <summary>
        /// Imports users from the csv file. if no path is defined, it takes form the Path property. imported users are saved to internal Users List
        /// </summary>
        /// <param name="path">Path for CSV file, default is internal Path</param>
        public void ImportUsers(string path = null)
        {
            if (path == null) path = Path;
            Users.Clear();
            string userImport;
            if (!File.Exists(path)) throw new FileNotFoundException("The Users csv file could not be found.");//this should not be caught. let program break
            StreamReader reader = new StreamReader(path);
            _ = reader.ReadLine(); //throwaway first line
            while ((userImport = reader.ReadLine()) != null)
            {
                string[] userInfo = userImport.Split(",");
                if (userInfo.Length != 6) continue;
                int id = int.Parse(userInfo[0]);
                string firstName = userInfo[1];
                string lastName = userInfo[2];
                string username = userInfo[3];
                decimal balance = decimal.Parse(userInfo[4]) / 100;
                string email = userInfo[5];
                Users.Add(new User(id, firstName, lastName, username, balance, email));
            }
        }
    }
}
