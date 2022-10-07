using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurencyConverter.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;
  public static string? Amount { get; set; }
  public static string? PreviousValue { get; set; }
  public static double ExchangeRate = 1.14;

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
    PreviousValue = null;
  }

  public void OnPost()
  {
    var amount = Request.Form["amount"];
    Amount = Math.Round(ToDouble(amount) * ExchangeRate, 2, MidpointRounding.ToEven).ToString();
    PreviousValue = amount.ToString();
    Response.Redirect("/");
  }
}
