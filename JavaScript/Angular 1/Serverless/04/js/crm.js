var crm = angular.module('crm', []);

function CustomersController($scope) {

    $scope.title = "Customer Relationship Management";

    $scope.customers = [
        {
            id : 1,
            name : 'Sathyaish Chakravarthy',
            city : 'Noida'
        }, 
        {
            id : 2,
            name : 'Anil Chakraverty',
            city : 'New Delhi'
        },
        {
            id : 3,
            name : 'Sanjeev Kumar',
            city : 'Bangalore'
        },
        {
            id : 4,
            name : 'Manjunatha Ranga',
            city : 'Calgary'
        }
    ];

    $scope.customers.add = function() {

        var lastCustomer = $scope.customers[$scope.customers.length - 1];
        var newId = lastCustomer.id + 1;
        
        var newCustomer = {
            id : newId,
            name : $scope.newCustomer.name,
            city : $scope.newCustomer.city  
        };

        $scope.customers.push(newCustomer);
    };
};

crm.controller('CustomersController', CustomersController);