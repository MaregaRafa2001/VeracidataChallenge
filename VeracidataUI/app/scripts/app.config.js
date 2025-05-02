(function () {
    'use strict';

    angular
        .module('customerApp')
        .config(config)
        .run(runBlock);

    config.$inject = ['$routeProvider', '$httpProvider'];
    function config($routeProvider, $httpProvider) {
        $routeProvider
            .when('/login', {
                templateUrl: 'app/views/auth/login.html',
                controller: 'LoginController',
                controllerAs: 'vm',
                requireAuth: false
            })
            .when('/register', {
                templateUrl: 'app/views/auth/register.html',
                controller: 'RegisterController',
                controllerAs: 'vm',
                requireAuth: false
            })
            .when('/customers', {
                templateUrl: 'app/views/customers/list.html',
                controller: 'CustomersController',
                controllerAs: 'vm',
                requireAuth: true
            })
            .when('/customers/create', {
                templateUrl: 'app/views/customers/create.html',
                controller: 'CustomerCreateController',
                controllerAs: 'vm',
                requireAuth: true
            })
            .when('/customers/edit/:id', {
                templateUrl: 'app/views/customers/edit.html',
                controller: 'CustomerEditController',
                controllerAs: 'vm',
                requireAuth: true
            })
            .otherwise({ redirectTo: '/login' });

        $httpProvider.interceptors.push('AuthInterceptor');
    }

    runBlock.$inject = ['$rootScope', '$location', 'AuthService'];
    function runBlock($rootScope, $location, AuthService) {
        $rootScope.$on('$routeChangeStart', function (event, next) {
            if (next.requireAuth && !AuthService.isAuthenticated()) {
                $location.path('/login');
            }
        });
    }
})();