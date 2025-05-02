angular.module('customerApp.controllers')
    .controller('CustomerCreateController', ['$scope', 'CustomerService', '$location', function ($scope, CustomerService, $location) {
        var vm = this;
        vm.customer = {
            name: '',
            nickname: '',
            phone: '',
            birthDate: '',
            email: '',
            password: '',
            active: false
        };

        vm.createCustomer = function () {
            CustomerService.create(vm.customer)
                .then(function (response) {
                    // Redirect to customer list after creation
                    $location.path('/customers');
                })
                .catch(function (error) {
                    alert('Failed to create customer: ' + error.message);
                });
                
        };
    }]);
