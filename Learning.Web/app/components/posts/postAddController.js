(function (app) {
    app.controller('postAddController', postAddController);
    postAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function postAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.post = {
            CreatedDate: new Date(),
            Status: true,
            Name: ""
        }
        $scope.ckeditorOptions = {
            language: 'vi',

        }

        loadParentCategory();
        $scope.Addpost = Addpost;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        }


        function Addpost() {
            apiService.post('api/post/create', $scope.post,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('posts');
                }, function (error) {

                });
        }
        function loadParentCategory() {
            apiService.get('api/postcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            }
            finder.popup();
        }

        loadParentCategory();
    }
})(angular.module('learning.posts'));