// loginController.js
angular.module('customerApp.controllers')
    .controller('LoginController', ['$location', 'AuthService', '$http', 'API_CONFIG', 
    function($location, AuthService, $http, API_CONFIG) {
        var vm = this;
        vm.credentials = {
            email: '',
            password: ''
        };

        vm.login = function() {
            $http.post(API_CONFIG.BASE_URL + API_CONFIG.AUTH_ENDPOINT + '/login', vm.credentials)
                .then(function(response) {
                    AuthService.login(response.data.token);
                    $location.path('/customers');
                })
                .catch(function(error) {
                    alert('Login failed: ' + error.data.message);
                });
        };

        vm.goToRegister = function() {
            $location.path('/register');
        };
    }]);