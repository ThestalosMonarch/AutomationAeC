using Automation.Domain.Models;
using Microsoft.Data.Sqlite;

namespace Automation.Infraestructure
{
    public class DatabaseActions
    {
        private readonly string ConnectionString = @"Data Source=.\Database\AutomationDatabase.db;";

        public DatabaseActions()
        {
            
        }
        /// <summary>
        /// salvar os cursos no banco de dados
        /// </summary>
        /// <param name="cursos"></param>
        public void SaveCursos(List<Cursos> cursos)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();

                    foreach (Cursos curso in cursos)
                    {
                        using (SqliteCommand command = new SqliteCommand("INSERT OR REPLACE INTO Conteudo (Titulo, Professor, [Carga Horaria], Descricao, Tipo) VALUES (@Titulo, @Professor, @CargaHoraria, @Descricao, @Tipo)", connection))
                        {
                            command.Parameters.AddWithValue("@Titulo", curso.title);
                            command.Parameters.AddWithValue("@Professor", curso.Professor);
                            command.Parameters.AddWithValue("@CargaHoraria", curso.Carga_Horaria);
                            command.Parameters.AddWithValue("@Descricao", curso.description);
                            command.Parameters.AddWithValue("@Tipo", "Curso");

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (SqliteException)
            {
                Console.WriteLine("Erro ao acessar o banco de dados.");
                throw;
            }
        }
    }
}