using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Infraestructure
{
    public static class EnviromentValidation
    {
        /// <summary>
        /// checar se existe conexão com a internet
        /// </summary>
        /// <returns></returns>
        public static void IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 1000); // Usa um endereço IP conhecido (por exemplo, servidor DNS do Google)
                    if (reply == null || reply.Status != IPStatus.Success)
                    {
                        throw new Exception("Sem conexão com a internet.");
                    }
                }
            }
            catch (PingException)
            {
                throw new Exception("Sem conexão com a internet.");
            }
        }
        /// <summary>
        /// Checar se o arquivo de banco de dados existe
        /// </summary>
        /// <returns></returns>
        public static void FileExists()
        {
            string filePath = @".\Database\AutomationDatabase.db";
            if (!File.Exists(filePath))
            {
                throw new Exception($"O arquivo de banco de dados não existe no caminho '{filePath}' ");
            }
        }
        /// <summary>
        /// Checa se o chrome está instalado
        /// </summary>
        /// <returns></returns>
        public static void IsGoogleChromeInstalled()
        {
            string[] caminhosChrome = {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\Application\\chrome.exe"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Google\\Chrome\\Application\\chrome.exe"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Google\\Chrome\\Application\\chrome.exe")
        };
            if (!caminhosChrome.Any(File.Exists))
            {
                throw new Exception("O Google Chrome não está instalado.");
            }
        }
    }
}
