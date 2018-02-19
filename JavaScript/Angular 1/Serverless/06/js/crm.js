(function(undefined) {
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
                $scope.onBtnAddNewCustomerClickHandler();
            }

            return true;
        };

        $scope.onBtnAddNewCustomerClickHandler = function() {

            // liCustomer_
            var customerId = $scope.customers.exists(
                $scope.newCustomer.name, 
                $scope.newCustomer.city);

            var listItem;
            if (customerId > 0) {
                // do the UI thing
                var listItem = angular.element(document.querySelector("#liCustomer_" + customerId));
                
                if (listItem === undefined) {
                    throw new Error("Error: could not find the duplicate customer Id in the list of existing customers.");
                }

                $("#divErrorMessageSection").show();
                listItem.addClass("backgroundRed");
                return false;
            }
            else {
                $("#divErrorMessageSection").hide();
                if (listItem !== undefined) {
                    listItem.removeClass("backgroundRed");
                }
            }

            $scope.customers.add();
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
                name : 'Ping Pong',
                city : 'New Delhi'
            },
            {
                id : 3,
                name : 'Ding Dong',
                city : 'Bangalore'
            },
            {
                id : 4,
                name : 'Sing Song',
                city : 'Calgary'
            }, 
            {
                id : 5,
                name : 'Ting Tong',
                city : 'Bucharest'
            }
        ];

        $scope.customers.add = function() {

            var lastCustomer = $scope.customers[$scope.customers.length - 1];
            var newId = lastCustomer.id + 1;
            
            var newCustomer = new $scope.Customer(
                newId, 
                $scope.newCustomer.name, 
                $scope.newCustomer.city);

            $scope.customers.push(newCustomer);
        };

        $scope.customers.exists = function(name, city) {

            if ($scope.customers === undefined || 
            $scope.customers.length === 0) {
                return 0;
            }

            for (var item in $scope.customers) {
                var customer = $scope.customers[item];
                if ((customer.name.toUpperCase() === name.toUpperCase()) && 
                    (customer.city.toUpperCase() === city.toUpperCase())) {
                    return customer.id;
                }
            }

            return 0;
        };

        $scope.Customer = function(id, name, city) {

            this.id = id;
            this.name = name;
            this.city = city;

            return this;
        };

        $scope.setButtonState();
        $("#divErrorMessageSection").hide();
    };

    crm.controller('CustomersController', CustomersController);
}());