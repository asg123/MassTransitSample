using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Messages.Commands;
using MassTransit;

namespace Web.Controllers
{
    public class CreateCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(CreateCustomerViewModel model)
        {
            Bus.Instance.Publish(new CreateCustomer 
            { 
                FirstName = model.FirstName, 
                LastName =  model.LastName,
                Id = Guid.NewGuid() 
            });
            return RedirectToAction("Index");
        }

    }
}
