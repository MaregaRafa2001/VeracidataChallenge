angular.module('customerApp.controllers')
    .controller('RegisterController', ['$location', 'AuthService', 
    function($location, AuthService) {
        var vm = this;
        vm.newUser = {
            name: '',
            nickName: '',
            phone: '',
            birthDate: '',
            email: '',
            password: '',
            active: true
        };

        vm.register = function() {
            if (vm.registerForm.$invalid) {
                alert('Please fill all required fields');
                return;
            }

            // Converter data para formato ISO
            vm.newUser.birthDate = new Date(vm.newUser.birthDate).toISOString();

            AuthService.register(vm.newUser)
                .then(function() {
                    alert('Registration successful! Please login.');
                    $location.path('/login');
                })
                .catch(function(error) {
                    console.error('Registration error:', error);
                    alert('Registration failed: ' + (error.data?.message || 'Server error'));
                });
        };

        vm.cancel = function() {
            $location.path('/login');
        };
    }]);