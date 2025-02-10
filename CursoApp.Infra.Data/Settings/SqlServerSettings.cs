using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CursoApp.Infra.Data.Settings
{
    public class SqlServerSettings
    {
        public static string ConnectionString => "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BDCursoApp; Integrated Security = True";
    }
}
