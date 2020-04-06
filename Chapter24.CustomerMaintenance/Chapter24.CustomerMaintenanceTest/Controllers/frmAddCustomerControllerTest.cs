using System;
using System.Collections.Generic;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chapter24.CustomerMaintenanceTest.Controllers
{
    [TestClass]
    public class frmAddCustomerControllerTest
    {
        private frmAddCustomerController _controller;
        private Mock<IfrmAddCustomer> _viewMock;
        private Mock<IModuleController> _moduleControllerMock;
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private Mock<IStateRepository> _stateRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            _viewMock = new Mock<IfrmAddCustomer>();

            _moduleControllerMock = new Mock<IModuleController>();

            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _stateRepositoryMock = new Mock<IStateRepository>();

            _controller = new frmAddCustomerController(_viewMock.Object, _stateRepositoryMock.Object,
                _customerRepositoryMock.Object, _moduleControllerMock.Object);

        }

        [TestMethod]
        public void OnLoad_StateComboBoxIsInitializedWithStates()
        {
            //Arrange
            List<State> states = new List<State>()
            {
                new State() {StateCode = "CA", StateName = "California"},
                new State() {StateCode = "AZ", StateName = "Arizona"}
            };
            _stateRepositoryMock.Setup(repository => repository.GetStates()).Returns(states);

            //Act
            _controller.OnLoad();

            //Assert
            _stateRepositoryMock.Verify(repository => repository.GetStates(), Times.Once);
            _viewMock.Verify(view => view.InitializeStateComboBox(states), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCustomer_CustomerIsNull_ArgumentNullExceptionIsThrown()
        {
            _controller.AddCustomer(null);
        }
    }
}
