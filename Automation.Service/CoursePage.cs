using Automation.Domain.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Service
{
    public class CoursePage
    {
        /// <summary>
        /// Caputar as horas da página do curso
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static string GetHours(IWebDriver driver)
        {
            try
            {

                IWebElement pElement = driver.FindElement(By.CssSelector("p.courseInfo-card-wrapper-infos[style='color: #ff8c2a;']"));
                return pElement.Text;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Não foi encontrado o elemento!");
                throw ex;
            }
        }
        /// <summary>
        /// Capturar os instrutores da pagina do curso
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static string GetInstructors(IWebDriver driver)
        {
            try
            {
                IWebElement instructorsElement = driver.FindElement(By.ClassName("instructor-title--name"));
                return instructorsElement.Text;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Não foi encontrado o elemento!");
                throw ex;
            }
        }

    }
}
