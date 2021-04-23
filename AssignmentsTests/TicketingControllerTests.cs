using Assignments.Areas.Ticketing.Controllers;
using Assignments.Areas.Ticketing.Models;
using Assignments.Areas.Ticketing.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using Xunit;

namespace AssignmentsTests
{
    public class TicketingControllerTests
    {
        
        [Fact]
        public void TicketsMethod_ReturnsAViewResult()
        {
            //arrange
            var rep = new Mock<ITicketRepository>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.Tickets("all");

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Edit_POST_ReturnsRedirectToActionResultIfModelStateIsValid()
        {
            //arrange
            var rep = new Mock<ITicketRepository>();
            var temp = new Mock<ITempDataDictionary>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.Edit("1", new Ticket());

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact]
        public void Add_POST_ReturnsRedirectToActionResultIfModelStateIsValid()
        {
            //arrange
            var rep = new Mock<ITicketRepository>();
            var controller = new TicketingController(rep.Object);
            var model = new TicketViewModel();

            //act
            var result = controller.Add(model);

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Add_POST_ReturnsViewResultIfModelStateIsInValid()
        {
            //arrange
            var rep = new Mock<ITicketRepository>();
            var controller = new TicketingController(rep.Object);
            var model = new TicketViewModel();

            //act
            controller.ModelState.AddModelError("Error", "This is a fake error");
            var result = controller.Add(model);

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Filter_POST_ReturnsRedirectToActionResult()
        {
            //arrange
            var rep = new Mock<ITicketRepository>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.Filter(new string[] { "all" });

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
