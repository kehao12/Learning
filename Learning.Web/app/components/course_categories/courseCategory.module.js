/// <reference path="../../../node_modules/angular/angular.js" />

(function () {
    angular.module('learning.course_categories', ['learning.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('course_categories', {
            url: "/course_categories",
            parent: 'base',
            templateUrl: "/app/components/course_categories/courseCategoryListView.html",
            controller: "courseCategoryListController"
        }).state('course_category_add', {
            url: "/course_category_add",
            parent: 'base',
            templateUrl: "/app/components/course_categories/courseCategoryAddView.html",
            controller: "courseCategoryAddController"
        }).state('course_category_edit', {
            url: "/course_category_edit/:id",
            parent: 'base',
            templateUrl: "/app/components/course_categories/courseCategoryEditView.html",
            controller: "courseCategoryEditController"
        });
    }
})();