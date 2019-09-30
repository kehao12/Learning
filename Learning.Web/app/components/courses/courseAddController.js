(function (app) {
    app.controller('courseAddController', courseAddController);
    courseAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function courseAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.course = {
            CreatedDate: new Date(),
            Status: true,
            Name: ""
        }
        $scope.ckeditorOptions = {
            language: 'vi',
        
        }
        
        loadParentCategory();
        $scope.AddCourse = AddCourse;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.course.Alias = commonService.getSeoTitle($scope.course.Name);
        }


        function AddCourse() {
            apiService.post('api/course/create', $scope.course,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('courses');
                }, function (error) {
                   
                });
        }
        function loadParentCategory() {
            apiService.get('api/coursecategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.course.Image = fileUrl;
            }
            finder.popup();
        }
        loadParentCategory();
    }
})(angular.module('learning.courses'));