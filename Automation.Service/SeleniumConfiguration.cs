using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Service
{
    public class SeleniumConfiguration
    {
        /// <summary>
        /// Inicializar o driver do Chrome na página incial da Alura.
        /// </summary>
        /// <returns>Chrome WebDriver</returns>
        public static IWebDriver CreateAndInitializeDriver()
        {
            try
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                var driver = new ChromeDriver();

                // Navegar até o site Alura
                driver.Navigate().GoToUrl("https://www.alura.com.br/");
                // Realizar algumas ações básicas, por exemplo, imprimir o título da página
                Console.WriteLine($"Título da Página: {driver.Title}");
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);
                return driver;
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"Erro ao inicializar o driver: {ex.Message}");
                throw;
            }
        }
    }
}