using Microsoft.AspNetCore.Mvc;

namespace _932021.abrosimova.margarita.lab11.Controllers;

public class CalculatorController : Controller
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    public IActionResult Manual()
        {
            if (Request.Method != "POST")
                return View();
            else
            {
                CalculatorDataModel model = new CalculatorDataModel();
                model.FirstValue = Request.Form["FirstValue"];
                model.SecondValue = Request.Form["SecondValue"];
                model.operation = Request.Form["operation"];
                model.showOperation = false;
                model.calculation();
                ViewBag.dataModel = model;
                return View("ResultPage");
            }
        }

        [HttpGet]
        public IActionResult ManualWithSeparateHandlers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManualWithSeparateHandlers(int dummyNum)
        {
            CalculatorDataModel model = new CalculatorDataModel();
            model.FirstValue = Request.Form["FirstValue"];
            model.SecondValue = Request.Form["SecondValue"];
            model.operation = Request.Form["operation"];
            model.showOperation = false;
            model.calculation();
            ViewBag.dataModel = model;
            return View("ResultPage");
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(CalculatorDataModel model)
        {          
            model.calculation();
            model.showOperation = true;
            ViewBag.dataModel = model;
            return View("ResultPage");
        }

        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBindingInParameters(string FirstValue, string SecondValue, string operation)
        {
            CalculatorDataModel model = new CalculatorDataModel();
            model.FirstValue = FirstValue;
            model.SecondValue = SecondValue;
            model.operation = operation;
            model.showOperation = true;
            model.calculation();
            ViewBag.dataModel = model;
            return View("ResultPage");
        }
}
