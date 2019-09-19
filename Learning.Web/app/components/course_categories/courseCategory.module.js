/// <reference path="../../../node_modules/angular/angular.js" />

(function () {
    angular.module('learning.course_categories', ['learning.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('course_categories', {
            url: "/course_categories",
            templateUrl: "/app/components/course_categories/courseCategoryListView.html",
            controller: "courseCategoryListController"
        });
    }
})();