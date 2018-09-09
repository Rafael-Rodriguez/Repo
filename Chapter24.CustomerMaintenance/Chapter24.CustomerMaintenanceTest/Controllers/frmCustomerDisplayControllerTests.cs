using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives;
using Chapter24.CustomerMaintenance.Perspectives.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Chapter24.CustomerMaintenanceTest.Controllers
{
    [TestClass]
    public class frmCustomerDisplayControllerTests
    {
        private frmCustomerDisplayController _sut;
        private Mock<IfrmCustomerDisplay> _viewMock;
        private Mock<IMessageBox> _messageBoxMock;
        private Mock<ICustomerRepository> _customerRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            _viewMock = new Mock<IfrmCustomerDisplay>();
            _messageBoxMock = new Mock<IMessageBox>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            _sut = new frmCustomerDisplayController(_viewMock.Object, _customerRepositoryMock.Object, _messageBoxMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DisplayCustomer_StringIsNull_ThrowsArgumentNullException()
        {
            _sut.DisplayCustomer(null);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DisplayCustomer_StringIsNotAInt_ThrowsFormatException()
        {
            _sut.DisplayCustomer("abc");
        }

        [TestMethod]
        public void DisplayCustomer_ValidCustomerString_CustomerRepositoryIsCalled()
        {
            int customerID = 35;

            _sut.DisplayCustomer(customerID.ToString());

            _customerRepositoryMock.Verify(repository => repository.GetCustomerById(customerID), Times.Once);
        }

        [TestMethod]
        public void DisplayCustomer_CustomerIDNotFound_ViewClearControlsIsCalled()
        {
            int customerID = 35;

            Customer invalidCustomer = null;
            _customerRepositoryMock.Setup(repository => repository.GetCustomerById(customerID)).Returns(invalidCustomer);

            _sut.DisplayCustomer(customerID.ToString());

            _viewMock.Verify(view => view.ClearControls(), Times.Once);
        }

        [TestMethod]
        public void DisplayCustomer_CustomerIDFound_ViewDisplayCustomerIsCalled()
        {
            int customerID = 35;

            Customer expectedCustomer = new Customer() { CustomerID = customerID };
            _customerRepositoryMock.Setup(repository => repository.GetCustomerById(customerID)).Returns(expectedCustomer);

            _sut.DisplayCustomer(customerID.ToString());

            _viewMock.Verify(view => view.DisplayCustomer(expectedCustomer), Times.Once);
        }
    }
}
