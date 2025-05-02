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
            if (confirm("Tem certeza que deseja excluir o cliente '" + id + "'?")) {
                CustomerService.delete(id).then(function () {
                    vm.loadCustomers();
                });
            }
        };

        vm.loadCustomers();
    }
})();
