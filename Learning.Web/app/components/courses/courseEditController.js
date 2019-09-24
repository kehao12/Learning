(function (app) {
    app.controller('courseEditController', courseEditController);
    courseEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function courseEditController() {
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
            apiService.get('api/coursecategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

    }
})(angular.module('learning.courses'));