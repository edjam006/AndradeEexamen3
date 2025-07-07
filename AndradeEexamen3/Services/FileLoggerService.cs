using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndradeEexamen3.Services
{
    public static class FileLoggerService
    {
        public static async Task AppendLogAsync(string texto)
        {
            string filename = Path.Combine(FileSystem.AppDataDirectory, "Logs_Andrade.txt");
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            await File.AppendAllTextAsync(filename, $"Se incluyó el registro [{texto}] el {fecha}\n");
        }

        public static async Task<string> LeerLogsAsync()
        {
            string filename = Path.Combine(FileSystem.AppDataDirectory, "Logs_Andrade.txt");
            return File.Exists(filename) ? await File.ReadAllTextAsync(filename) : "Sin registros.";
        }
    }
}
