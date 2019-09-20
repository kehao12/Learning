(function (app) {
    app.controller('courseCategoryListController', courseCategoryListController);
    courseCategoryListController.$inject = ['$scope', 'apiService'];

    function courseCategoryListController($scope, apiService) {
        
        $scope.courseCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getCourseCategories = getCourseCategories;


        function getCourseCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/coursecategory/getall', config, function (result) {

                $scope.courseCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

              
            }, function () {
                    console.log('Load failed');
            });
        }
        $scope.getCourseCategories();
    }
})(angular.module('learning.course_categories'));