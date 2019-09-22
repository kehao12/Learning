(function (app) {
    app.controller('courseCategoryListController', courseCategoryListController);
    courseCategoryListController.$inject = ['$scope', 'apiService','notificationService'];

    function courseCategoryListController($scope, apiService, notificationService) {
        
        $scope.courseCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getCourseCategories = getCourseCategories;


        $scope.search = search;

        function search() {
            getCourseCategories();
        }

        function getCourseCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/coursecategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không bảng ghi nào được tìm thấy.");
                }
                else {
                    notificationService.displaySuccess("Đã tìm thấy " + result.data.TotalCount + " bản ghi.");
                }
                $scope.courseCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                    console.log('Load coursecategory failed.');
            });
        }
        $scope.getCourseCategories();
    }
})(angular.module('learning.course_categories'));