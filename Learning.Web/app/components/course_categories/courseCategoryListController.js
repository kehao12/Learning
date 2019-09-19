(function (app) {
    app.controller('courseCategoryListController', courseCategoryListController);
    courseCategoryListController.$inject = ['$scope', 'apiService'];

    function courseCategoryListController($scope, apiService) {
        
        $scope.courseCategories = [];
        $scope.getCourseCategories = getCourseCategories;

        function getCourseCategories() {
            apiService.get('/api/coursecategory/getall', null, function (result) {
                $scope.courseCategories = result.data;
              
            }, function () {
                    console.log('Load failed');
            });
        }
        $scope.getCourseCategories();
    }
})(angular.module('learning.course_categories'));