using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro
{
    internal class AppSettings
    {
        private static string DatabaseName = "DatabaseName.db";
        private static string DatabasePath = FileSystem.AppDataDirectory;
        public static string DatabaseFullPath = Path.Combine(DatabasePath, DatabaseName);
    }
}
