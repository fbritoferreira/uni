using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurencyConverter.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;
  public static string? Amount { get; set; }
  public static string? PreviousValue { get; set; }

  public IndexModel(ILogger<IndexModel> logger)
  {
    _logger = logger;
  }

  public static double ToDouble(string strValue)
  {
    double.TryParse(strValue, out double result);
    return result;
  }

  public void OnGet()
  {
    if (Amount == null || Amount == "0")
    {
      Amount = null;
    }

    ViewData["Amount"] = Amount;
    ViewData["PreviousValue"] = PreviousValue;
    Amount = null;

  }

  public void OnPost()
  {
    var amount = Request.Form["amount"];
    var exchangeRate = 1.14;
    var valueInEuros = Math.Round(ToDouble(amount) * exchangeRate, 2, MidpointRounding.ToEven);

    Amount = valueInEuros.ToString();
    PreviousValue = amount.ToString();

    Response.Redirect("/");
  }
}
