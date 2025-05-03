(function () {
    'use strict';

    angular
        .module('customerApp.services')
        .factory('AuthService', AuthService);

    // Adicione $http e API_CONFIG nas dependências
    AuthService.$inject = ['$http', '$window', '$location', 'API_CONFIG'];
    
    function AuthService($http, $window, $location, API_CONFIG) {
        const TOKEN_KEY = 'auth_token';

        return {
            login: function(token) {
                $window.localStorage.setItem(TOKEN_KEY, token);
            },
            logout: function() {
                $window.localStorage.removeItem(TOKEN_KEY);
                $location.path('/login');
            },
            getToken: function() {
                return $window.localStorage.getItem(TOKEN_KEY);
            },
            isAuthenticated: function() {
                return !!this.getToken?.();
            },            
            register: function(userData) {
                return $http.post(
                    API_CONFIG.BASE_URL + API_CONFIG.AUTH_ENDPOINT + '/register', 
                    userData
                );
            }
        };
    }
})();