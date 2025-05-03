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
        vm.customerId = $routeParams.id;
        vm.isLoading = true;
        vm.updateCustomer = updateCustomer;

        loadCustomer();

        function loadCustomer() {

            CustomerService.getById(vm.customerId)
                .then(function(response) {
                    vm.customer = response.data;
                    if (vm.customer.birthDate) {
                        vm.customer.birthDate = new Date(vm.customer.birthDate);
                    }
                    vm.isLoading = false;
                })
                .catch(function(error) {
                    console.error('Error loading customer:', error);
                    $location.path('/customers');
                });
        }

        function updateCustomer() {
            if (vm.customerForm.$invalid) {
                alert('Please fill all required fields');
                return;
            }

            CustomerService.update(vm.customerId, vm.customer)
                .then(function() {
                    $location.path('/customers');
                })
                .catch(function(error) {
                    console.error('Error updating customer:', error);
                    alert('Error updating customer: ' + (error.data?.message || 'Server error'));
                });
        }

        vm.cancel = function() {
            $location.path('/customers');
        };
    }
})();