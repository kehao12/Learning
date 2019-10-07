﻿/// <reference path="../../../node_modules/angular/angular.js" />

(function () {
    angular.module('learning.post_categories', ['learning.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('post_categories', {
            url: "/post_categories",
            parent:"base",
            templateUrl: "/app/components/post_categories/postCategoryListView.html",
            controller: "postCategoryListController"
        }).state('post_category_add', {
            url: "/post_category_add",
            parent: "base",
            templateUrl: "/app/components/post_categories/postCategoryAddView.html",
            controller: "postCategoryAddController"
        }).state('post_category_edit', {
            url: "/post_category_edit/:id",
            parent: "base",
            templateUrl: "/app/components/post_categories/postCategoryEditView.html",
            controller: "postCategoryEditController"
        });
    }
})();