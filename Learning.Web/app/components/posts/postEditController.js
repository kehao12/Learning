(function (app) {
    app.controller('postEditController', postEditController);
    postEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function postEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.post = {
            CreatedDate: new Date(),
            Status: true,

        }
        $scope.ckeditorOptions = {
            language: 'vi',

        }
        loadParentCategory();
        $scope.Updatepost = Updatepost;

        function Updatepost() {
            apiService.put('api/post/update', $scope.post,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('posts');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadParentCategory() {
            apiService.get('api/post/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        function loadpostDetail() {
            apiService.get('api/post/getbyid/' + $stateParams.id, null, function (result) {
                $scope.post = result.data;
                console.log($scope.post);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            }
            finder.popup();
        }

        loadpostDetail();
    }
})(angular.module('learning.posts'));