// app/scripts/controllers/customerEditController.js
(function() {
    'use strict';

    angular
        .module('customerApp.controllers')
        .controller('CustomerEditController', CustomerEditController);

    CustomerEditController.$inject = ['$routeParams', '$location', 'CustomerService'];

    function CustomerEditController($routeParams, $location, CustomerService) {
        var vm = this;
        vm.customer = {};
        vm.isLoading = true;
        vm.updateCustomer = updateCustomer;

        // Carrega o cliente para edição
        loadCustomer();

        function loadCustomer() {
            var customerId = $routeParams.id;
            
            CustomerService.getById(customerId)
                .then(function(response) {
                    vm.customer = response.data;
                    vm.isLoading = false;
                })
                .catch(function(error) {
                    console.error('Error loading customer:', error);
                    $location.path('/customers');
                });
        }

        function updateCustomer() {
            if (vm.editForm.$invalid) {
                alert('Please fill all required fields');
                return;
            }

            CustomerService.updateCustomer(vm.customer)
                .then(function() {
                    $location.path('/customers');
                })
                .catch(function(error) {
                    console.error('Error updating customer:', error);
                    alert('Error updating customer: ' + (error.data?.message || 'Server error'));
                });
        }
    }
})();