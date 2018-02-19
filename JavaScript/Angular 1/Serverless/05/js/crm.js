(function() {
    var crm = angular.module('crm', []);

    function CustomersController($scope) {

        $scope.title = "Customer Relationship Management";

        $scope.setButtonState = function() {
            var nameHasText = !!$("#txtName").val();
            var cityHasText =  !!$("#txtCity").val();
            
            var enable = (nameHasText && cityHasText);
            $("#btnAddNewCustomer").prop("disabled", !enable);

            return enable;
        };

        $scope.onKeyUpEventHandler = function($event) {

            var keyCode = $event.keyCode;
            var enterKeyCode = 13;

            console.log($event.target.name + ' ' + keyCode);
            
            var buttonEnabled = $scope.setButtonState();
            
            if (!buttonEnabled) return false;

            if (keyCode === enterKeyCode) {
                $scope.customers.add();
            }

            return true;
        };

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

        $scope.setButtonState();
    };

    crm.controller('CustomersController', CustomersController);
}());