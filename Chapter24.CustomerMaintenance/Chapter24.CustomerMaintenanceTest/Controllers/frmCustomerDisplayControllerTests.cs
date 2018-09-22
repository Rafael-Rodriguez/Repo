using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives;
using Chapter24.CustomerMaintenance.Perspectives.Components;
using Chapter24.CustomerMaintenance.Services;
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
        private Mock<IModuleController> _moduleControllerMock;

        [TestInitialize]
        public void Initialize()
        {
            _viewMock = new Mock<IfrmCustomerDisplay>();
            _messageBoxMock = new Mock<IMessageBox>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _moduleControllerMock = new Mock<IModuleController>();

            _sut = new frmCustomerDisplayController(_viewMock.Object, _customerRepositoryMock.Object, _messageBoxMock.Object, _moduleControllerMock.Object);
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

        [TestMethod]
        public void AddCustomer_ProgramFlowManagerAddCustomerIsCalled()
        {
            Mock<IProgramFlowManager> _programFlowManagerMock = new Mock<IProgramFlowManager>();

            _moduleControllerMock.Setup(controller => controller.GetService<IProgramFlowManager>()).Returns(_programFlowManagerMock.Object);

            _sut.AddCustomer();

            _programFlowManagerMock.Verify(flowManager => flowManager.AddNewCustomer(), Times.Once);
        }

        [TestMethod]
        public void AddCustomer_ProgramFlowManagerAddCustomerReturnsNull_CustomerIsNotDisplayed()
        {
            Mock<IProgramFlowManager> _programFlowManagerMock = new Mock<IProgramFlowManager>();
            Customer customer = null;

            _moduleControllerMock.Setup(controller => controller.GetService<IProgramFlowManager>()).Returns(_programFlowManagerMock.Object);
            _programFlowManagerMock.Setup(flowManager => flowManager.AddNewCustomer()).Returns(customer);

            _sut.AddCustomer();

            _customerRepositoryMock.Verify(repository => repository.GetCustomerById(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void AddCustomer_ProgramFlowManagerAddCustomerReturnsCustomer_DisplayCustomerIDIsCalled()
        {
            Mock<IProgramFlowManager> _programFlowManagerMock = new Mock<IProgramFlowManager>();
            Customer customer = new Customer();

            _moduleControllerMock.Setup(controller => controller.GetService<IProgramFlowManager>()).Returns(_programFlowManagerMock.Object);
            _programFlowManagerMock.Setup(flowManager => flowManager.AddNewCustomer()).Returns(customer);

            _sut.AddCustomer();

            _customerRepositoryMock.Verify(repository => repository.GetCustomerById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyCustomer_CustomerIsNull_ArgumentNullExceptionIsThrown()
        {
            _sut.ModifyCustomer(null);
        }

        [TestMethod]
        public void ModifyCustomer_ProgramFlowManagerModifyCustomerIsCalled()
        {
            Mock<IProgramFlowManager> _programFlowManagerMock = new Mock<IProgramFlowManager>();
            Customer customer = new Customer();

            _moduleControllerMock.Setup(controller => controller.GetService<IProgramFlowManager>()).Returns(_programFlowManagerMock.Object);

            _sut.ModifyCustomer(customer);

            _programFlowManagerMock.Verify(flowManager => flowManager.ModifyCustomer(customer), Times.Once);
        }

        [TestMethod]
        public void ModifyCustomer_ProgramFlowManagerModifyCustomerReturnsNull_CustomerIsNotDisplayed()
        {
            Mock<IProgramFlowManager> _programFlowManagerMock = new Mock<IProgramFlowManager>();
            Customer customer = new Customer();
            Customer modifiedCustomer = null;

            _moduleControllerMock.Setup(controller => controller.GetService<IProgramFlowManager>()).Returns(_programFlowManagerMock.Object);
            _programFlowManagerMock.Setup(flowManager => flowManager.ModifyCustomer(customer)).Returns(modifiedCustomer);

            _sut.ModifyCustomer(customer);

            _customerRepositoryMock.Verify(repository => repository.GetCustomerById(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void ModifyCustomer_ProgramFlowManagerModifyCustomerReturnsCustomer_DisplayCustomerIDIsCalled()
        {
            Mock<IProgramFlowManager> _programFlowManagerMock = new Mock<IProgramFlowManager>();
            Customer customer = new Customer();

            _moduleControllerMock.Setup(controller => controller.GetService<IProgramFlowManager>()).Returns(_programFlowManagerMock.Object);
            _programFlowManagerMock.Setup(flowManager => flowManager.ModifyCustomer(customer)).Returns(customer);

            _sut.ModifyCustomer(customer);

            _customerRepositoryMock.Verify(repository => repository.GetCustomerById(It.IsAny<int>()), Times.Once);
        }
    }
}
