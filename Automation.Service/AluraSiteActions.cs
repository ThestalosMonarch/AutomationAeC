using Automation.Domain.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Service
{
    /// <summary>
    /// Todas as ações pricipais na pagina alura com selenium são feitas aqui
    /// </summary>
    public class AluraSiteActions
    {
        /// <summary>
        /// Realizar Pesquisa no site
        /// </summary>
        /// <param name="driver"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void SearchContent(IWebDriver driver)
        {

            Console.WriteLine("Digite o texto que deseja pesquisar no site Alura: ");
            string texto = Console.ReadLine();
            int tentativas = 0;

            while (string.IsNullOrEmpty(texto) && tentativas < 3)
            {
                Console.WriteLine("É necessário digitar algo para que a pesquisa do site possa prosseguir");

                tentativas++;

                if (tentativas >= 3)
                {
                    Console.WriteLine("Devido à não inserção de nenhum caractere, a automação será encerrada");
                    throw new InvalidOperationException("Usuário não forneceu texto de pesquisa.");
                }

                Console.WriteLine($"Tentativa {tentativas}/3");
                texto = Console.ReadLine();
            }
            IWebElement campoBusca = driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));

            // Inserindo o texto que você deseja pesquisar
            campoBusca.SendKeys(texto);
            // Submetendo o formulário (pode variar dependendo da implementação do site)
            campoBusca.Submit();
        }
        /// <summary>
        /// Filtrar conteúdo com base em curso
        /// </summary>
        /// <param name="driver"></param>
        public static void FilterContent(IWebDriver driver)
        {
            Console.Write("Selecionando Cursos e Formações conforme texto de busca...");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement filter = wait.Until(c => c.FindElement(By.XPath("/html/body/div[2]/div[2]/div/span")));
            System.Threading.Thread.Sleep(1000);
            filter.Click();

            string primeiroElementoSelector = "#busca--filtros--tipos > li:nth-child(1) > label > div > span.busca--filtro--nome-filtro";
            IWebElement primeiroElemento = wait.Until(c => c.FindElement(By.CssSelector(primeiroElementoSelector)));
            primeiroElemento.Click();

            IWebElement buscar = driver.FindElement(By.Id("busca-form-input"));
            buscar.Submit();
        }
        /// <summary>
        /// Capturar informações no site Alura referente aos cursos. Este metodo pode ficar mais genérico caso seja preciso capturar outros tipos de conteúdo
        /// </summary>
        /// <param name="driver"></param>
        public static List<Cursos> GetContentResultInformation(IWebDriver driver)
        {

            IWebElement ulElement = driver.FindElement(By.CssSelector("ul.paginacao-pagina"));
            IList<IWebElement> liElements = ulElement.FindElements(By.CssSelector("li.busca-resultado"));
            
            List<Cursos> cursosEncontrados = new List<Cursos>();
            foreach (IWebElement liElement in liElements)
            {
                #region Pegar informação do título e descrição
                string titulo = liElement.FindElement(By.CssSelector("h4.busca-resultado-nome")).Text;
                string descricao = liElement.FindElement(By.CssSelector("p.busca-resultado-descricao")).Text;
                Console.WriteLine($"Item Name: {titulo}\nItem Description: {descricao}\n");
                #endregion
                #region Capturar o link para acessar as demais informações
                IWebElement link = liElement.FindElement(By.CssSelector(".busca-resultado-link"));
                string href = link.GetAttribute("href");
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

                driver.Navigate().GoToUrl(href);
                string horas = CoursePage.GetHours(driver);
                string instrutores = CoursePage.GetInstructors(driver);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                #endregion
                Cursos curso = new Cursos(titulo, descricao, horas, instrutores);
                cursosEncontrados.Add(curso);
            }
            return cursosEncontrados;
        }

    }
}
