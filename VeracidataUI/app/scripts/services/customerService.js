(function () {
    'use strict';

    angular
        .module('customerApp.services')
        .factory('CustomerService', CustomerService);

    CustomerService.$inject = ['$http', 'API_CONFIG'];

    function CustomerService($http, API_CONFIG) {
        const baseUrl = API_CONFIG.BASE_URL + API_CONFIG.CUSTOMERS_ENDPOINT;

        return {
            getAll: function () {
                return $http.get(baseUrl);
            },
            getById: function (id) {
                return $http.get(`${baseUrl}/${id}`);
            },
            create: function (customer) {
                return $http.post(baseUrl, customer);
            },
            update: function (id, customer) {
                return $http.put(`${baseUrl}/${id}`, customer);
            },
            delete: function (id) {
                return $http.delete(`${baseUrl}/${id}`);
            }
        };
    }
})();
