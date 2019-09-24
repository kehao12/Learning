(function (app) {
    app.controller('courseCategoryAddController', courseCategoryAddController);

    courseCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function courseCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.courseCategory = {
            CreatedDate: new Date(),
            Status: true,
            Name: ""
        }
        loadParentCategory();
        $scope.AddCourseCategory = AddCourseCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.courseCategory.Alias = commonService.getSeoTitle($scope.courseCategory.Name);
        }

        function AddCourseCategory() {
            apiService.post('api/coursecategory/create', $scope.courseCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('course_categories');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadParentCategory() {
            apiService.get('api/coursecategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

      
    }

})(angular.module('learning.course_categories'));