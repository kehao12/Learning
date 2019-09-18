/// <reference path="../../../node_modules/angular/angular.js" />

(function () {
    angular.module('learning.courses', ['learning.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('courses', {
            url: "/courses",
            templateUrl: "/app/components/courses/courseListView.html",
            controller: "courseListController"
        }).state('course_add', {
            url: "/course_add",
            templateUrl: "/app/components/courses/courseAddView.html",
            controller: "courseAddController"
        }).state('course_edit', {
            url: "/course_edit",
            templateUrl: "/app/components/courses/courseEditView.html",
            controller: "courseEditController"
        });
    }
})();