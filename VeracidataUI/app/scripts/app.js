// app/scripts/app.js
(function () {
    'use strict';

    angular
        .module('customerApp', [
            'ngRoute',
            'customerApp.controllers',
            'customerApp.services'
        ])
        .constant('API_CONFIG', {
            BASE_URL: 'https://localhost:7205/api', // Sua API URL
            AUTH_ENDPOINT: '/auth',
            CUSTOMERS_ENDPOINT: '/customers'
        });
})();