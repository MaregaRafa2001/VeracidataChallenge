// authInterceptor.js
(function () {
    'use strict';

    angular
        .module('customerApp.services')
        .factory('AuthInterceptor', AuthInterceptor);

    AuthInterceptor.$inject = ['$q', '$location'];
    
    function AuthInterceptor($q, $location) {
        const TOKEN_KEY = 'auth_token';

        return {
            request: function(config) {
                const token = localStorage.getItem(TOKEN_KEY); // Acesso direto
                if (token) {
                    config.headers.Authorization = 'Bearer ' + token;
                }
                return config;
            },
            responseError: function(rejection) {
                if (rejection.status === 401) {
                    localStorage.removeItem(TOKEN_KEY); // Remove diretamente
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    }
})();