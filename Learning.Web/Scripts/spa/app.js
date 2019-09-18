/// <reference path="../node_modules/angular/angular.js" />

var myApp = angular.module('myModule', []);
myApp.controller("schoolController", schoolController);

myApp.service('ValidatorService', ValidatorService);

myApp.directive('teduShopDirective', teduShopDirective);

schoolController.$inject = ['$scope', 'ValidatorService'];

function schoolController($scope, ValidatorService) {

    $scope.checkNumber = function () {
        $scope.message = ValidatorService.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function ValidatorService($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return 'This is even';
        }
        else
            return 'This is odd';
    }

}

function teduShopDirective() {
    return {
        templateUrl:"/Scripts/spa/test.html"
    }
}