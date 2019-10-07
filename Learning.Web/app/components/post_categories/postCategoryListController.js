(function (app) {
    app.controller('postCategoryListController', postCategoryListController);
    postCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function postCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.postCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getpostCategories = getpostCategories;


        $scope.search = search;

        $scope.deletepostCategory = deletepostCategory;
        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedpostCategories: JSON.stringify(listId)
                }
            }
            apiService.del('api/postcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.postCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.postCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }


        $scope.$watch("postCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deletepostCategory(id, name) {
            $ngBootbox.confirm('Bạn có chắc muốn xoá " ' + name + ' " ').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/postcategory/delete', config, function () {
                    notificationService.displaySuccess('Xoá thành công' + name);
                    $scope.getpostCategories();
                })

            }, function () {
                notificationService.displayWarning('Xoá không thành công');
            });
        }

        function search() {
            getpostCategories();
        }

        function getpostCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/postcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không bảng ghi nào được tìm thấy.");
                }
                else {
                    notificationService.displaySuccess("Đã tìm thấy " + result.data.TotalCount + " bản ghi.");
                }
                $scope.postCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load postcategory failed.');
            });
        }
        $scope.getpostCategories();
    }
})(angular.module('learning.post_categories'));