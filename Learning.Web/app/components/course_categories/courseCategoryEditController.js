(function (app) {
    app.controller('courseCategoryEditController', courseCategoryEditController);

    courseCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function courseCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.courseCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateCourseCategory = UpdateCourseCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.courseCategory.Alias = commonService.getSeoTitle($scope.courseCategory.Name);
        }

        function loadcourseCategoryDetail() {
            apiService.get('api/coursecategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.courseCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateCourseCategory() {
            apiService.put('api/coursecategory/update', $scope.courseCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('course_categories');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadParentCategory() {
            apiService.get('api/coursecategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadParentCategory();
        loadcourseCategoryDetail();
    }

})(angular.module('learning.course_categories'));