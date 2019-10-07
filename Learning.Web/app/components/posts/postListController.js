(function (app) {
    app.controller('postListController', postListController);
    postListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function postListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.post = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getpost = getpost;

        $scope.deletepost = deletepost;


        function deletepost(id, name) {
            $ngBootbox.confirm('Bạn có chắc muốn xoá " ' + name + ' " ').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/post/delete', config, function () {
                    notificationService.displaySuccess('Xoá thành công' + name);
                    $scope.getpost();
                })

            }, function () {
                notificationService.displayWarning('Xoá không thành công');
            });
        }

        function getpost(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 4
                }
            }
            apiService.get('/api/post/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không bảng ghi nào được tìm thấy.");
                }
                else {
                    notificationService.displaySuccess("Đã tìm thấy " + result.data.TotalCount + " bản ghi.");
                }
                $scope.post = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load post failed.');
            });
        }
        $scope.getpost();
    }
})(angular.module('learning.posts'));