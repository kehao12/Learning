(function (app) {
    app.controller('courseAddController', courseAddController);
    courseAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function courseAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.course = {
            CreatedDate: new Date(),
            Status: true,
            Name: ""
        }
        loadParentCategory();
        $scope.AddCourse = AddCourse;

        function AddCourse() {
            apiService.post('api/course/create', $scope.course,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('courses');
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
        loadParentCategory();
    }
})(angular.module('learning.courses'));