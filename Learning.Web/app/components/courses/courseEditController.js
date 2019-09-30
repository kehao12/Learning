(function (app) {
    app.controller('courseEditController', courseEditController);
    courseEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function courseEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.course = {
            CreatedDate: new Date(),
            Status: true,
       
        }
        loadParentCategory();
        $scope.UpdateCourse = UpdateCourse;

        function UpdateCourse() {
            apiService.put('api/course/update', $scope.course,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('courses');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadParentCategory() {
            apiService.get('api/course/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        function loadcourseDetail() {
            apiService.get('api/course/getbyid/' + $stateParams.id, null, function (result) {
                $scope.course = result.data;
                console.log($scope.course);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        loadcourseDetail();
    }
})(angular.module('learning.courses'));