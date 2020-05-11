using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp
{
    [IgnoreAntiforgeryToken]
    public class ExchangeModel : PageModel
    {
        public string Message { get; set; }
        public decimal currentRate => 64.1m;
        public void OnGet()
        {
            Message = "Введите сумму";
        }

        //public void OnPost(int? summ)
        //{

        //    if (summ == null || summ < 1000)
        //    {
        //        Message = "Передана некорректная сумма";
        //    }
        //    else
        //    {
        //        decimal result = summ.Value / currentRate;
        //        // ToString("F2") - форматирование числа: F2 - дробное число с 2 знаками после запятой
        //        Message = $"При обмене {summ} рублей вы получите {result.ToString("F2")}$.";
        //    }
        //}
    }
}