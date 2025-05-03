(function () {
    'use strict';

    angular
        .module('customerApp.controllers')
        .controller('CustomersController', CustomersController);

    CustomersController.$inject = ['CustomerService'];

    function CustomersController(CustomerService) {
        var vm = this;
        vm.customers = [];

        vm.loadCustomers = function () {
            CustomerService.getAll().then(function (data) {
                vm.customers = data.data;
            });
        };

        vm.deleteCustomer = function (id) {
            if (confirm("Are you sure you want to delete customer '" + id + "'?")) {
                CustomerService.delete(id).then(function () {
                    vm.loadCustomers();
                });
            }
        };

        vm.loadCustomers();
    }
})();
