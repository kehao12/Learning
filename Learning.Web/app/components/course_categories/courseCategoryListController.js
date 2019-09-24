(function (app) {
    app.controller('courseCategoryListController', courseCategoryListController);
    courseCategoryListController.$inject = ['$scope', 'apiService','notificationService','$ngBootbox','$filter'];

    function courseCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        
        $scope.courseCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getCourseCategories = getCourseCategories;


        $scope.search = search;

        $scope.deleteCourseCategory = deleteCourseCategory;
        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedCourseCategories: JSON.stringify(listId)
                }
            }
            apiService.del('api/coursecategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.courseCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.courseCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }


        $scope.$watch("courseCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteCourseCategory(id,name) {
            $ngBootbox.confirm('Bạn có chắc muốn xoá " '+ name+' " ').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/coursecategory/delete', config, function () {
                    notificationService.displaySuccess('Xoá thành công' + name);
                    $scope.getCourseCategories();
                })

            }, function () {
                notificationService.displayWarning('Xoá không thành công');
            });
        }

        function search() {
            getCourseCategories();
        }

        function getCourseCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/coursecategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không bảng ghi nào được tìm thấy.");
                }
                else {
                    notificationService.displaySuccess("Đã tìm thấy " + result.data.TotalCount + " bản ghi.");
                }
                $scope.courseCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                    console.log('Load coursecategory failed.');
            });
        }
        $scope.getCourseCategories();
    }
})(angular.module('learning.course_categories'));