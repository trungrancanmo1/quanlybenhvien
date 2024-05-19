using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Database
    {
        private static Database instance;
        public FirestoreDb database;
        public static Database Instance { 
            get
            {
                if (instance == null)
                    instance = new Database();
                return instance;
            }
            private set => instance = value;
        }
        public Database()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("test-964d0");
        }
    }
}
