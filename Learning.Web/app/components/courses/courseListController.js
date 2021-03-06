﻿(function (app) {
    app.controller('courseListController', courseListController);
    courseListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function courseListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.course = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getCourse = getCourse;

        $scope.deleteCourse = deleteCourse;


        function deleteCourse(id, name) {
            $ngBootbox.confirm('Bạn có chắc muốn xoá " ' + name + ' " ').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/course/delete', config, function () {
                    notificationService.displaySuccess('Xoá thành công' + name);
                    $scope.getCourse();
                })

            }, function () {
                notificationService.displayWarning('Xoá không thành công');
            });
        }

        function getCourse(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 4
                }
            }
            apiService.get('/api/course/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không bảng ghi nào được tìm thấy.");
                }
                else {
                    notificationService.displaySuccess("Đã tìm thấy " + result.data.TotalCount + " bản ghi.");
                }
                $scope.course = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load course failed.');
            });
        }
        $scope.getCourse();
    }
})(angular.module('learning.courses'));