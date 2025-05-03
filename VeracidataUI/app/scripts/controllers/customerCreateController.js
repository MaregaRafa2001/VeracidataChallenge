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

            if (vm.customerForm.$invalid) {
                alert('Please fill all required fields');
                return;
            }

            CustomerService.create(vm.customer)
                .then(function (response) {
                    // Redirect to customer list after creation
                    $location.path('/customers');
                })
                .catch(function (error) {
                    alert('Unable to create customer. \nA user with this name already exists. Please choose a different name and try again.');
                });
                
        };

        vm.cancel = function() {
            $location.path('/customers');
        };
    }]);
